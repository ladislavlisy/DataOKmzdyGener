using OKmzdy.SqlSchemaInfo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DataOKmzdyGener10
{  
    class DataSourceGenerator
    {
        const string TAB_INDENT0 = "";
        const string TAB_INDENT1 = "\t";
        const string TAB_INDENT2 = "\t\t";
        const string TAB_INDENT3 = "\t\t\t";

        const string SP_INDENT0 = "";
        const string SP_INDENT1 = "    ";
        const string SP_INDENT2 = "        ";
        const string SP_INDENT3 = "            ";

        const UInt32 m_numDataVers = 1602;

        static Tuple<string, string>[] m_ConfigEntityNames = new Tuple<string, string>[] {
            new Tuple<string, string>("Ppom", "PPom"),
            new Tuple<string, string>("Vrep", "VRep"),
            new Tuple<string, string>("Uimp", "UImp"),
            new Tuple<string, string>("Ulst", "ULst"),
            new Tuple<string, string>("SestavyUdata", "SestavyData"),
            new Tuple<string, string>("Pmedia", "PMedia"),
            new Tuple<string, string>("PrijmySsp", "PrijmySSP"),
            new Tuple<string, string>("HlaseniZp", "HlaseniZP")
        };


    public static bool CreateContextClassBlock(TextWriter textWriter, IList<TableDefInfo> tableList, string blokIndent, string contextName)
        {
            bool uspesnaCast = true;

            blokIndent += TAB_INDENT1;
            textWriter.WriteLine(blokIndent + "public class " + contextName.ConvertNameToCamel() + "Context : DbContext");
            textWriter.WriteLine(blokIndent + "{");

            textWriter.WriteLine(blokIndent + "#region " + contextName.ConvertNameToCamel() + ".Tables");

            foreach (var tableDef in tableList)
            {
                CreateContextClassTableBlock(textWriter, tableDef, blokIndent, contextName);
            }

            textWriter.WriteLine(blokIndent + "#endregion");

            CreateContextClassModelBlock(textWriter, tableList, blokIndent, contextName);

            textWriter.WriteLine(blokIndent + "}");

            return uspesnaCast;
        }

        public static void CreateConfigsClassFile(BaseSchemaManager schema, string contextName, IList<TableDefInfo> tableList, string resultFileName)
        {
            using (TextWriter writer = File.CreateText(resultFileName))
            {
                string blokIndent = "";

                writer.WriteLine("using System;");
                writer.WriteLine("using System.Linq;");
                writer.WriteLine("using System.Text;");
                writer.WriteLine("using System.Threading.Tasks;");
                writer.WriteLine("using System.Data.Entity;");
                writer.WriteLine("using System.Data.Entity.ModelConfiguration;");
                writer.WriteLine("using " + schema.SchemaNamespace() + ".EntityModel;");
                writer.WriteLine("");
                writer.WriteLine("namespace " + schema.SchemaNamespace() + ".EntityConfiguration");
                writer.WriteLine("{");

                foreach (TableDefInfo tableDef in tableList)
                {
                    CreateConfigsClassTableBlock(writer, tableDef, blokIndent);
                }

                writer.WriteLine(blokIndent + "}");
            }
        }

        public static void CreateEntityClassFiles(BaseSchemaManager schema, string contextName, IList<TableDefInfo> tableList, string resultFoldName)
        {
            foreach (TableDefInfo tableDef in tableList)
            {
                CreateEntityClassSourceFile(schema, tableDef, contextName, resultFoldName);
            }
        }

        private static void CreateEntityClassSourceFile(BaseSchemaManager schema, TableDefInfo tableInfo, string contextName, string resultFoldName)
        {
            string tableName = tableInfo.Name();

            string className = TableDefInfo.ClassName(m_ConfigEntityNames, tableInfo.CodeFirstEntityName());

            string sourcesFoldPath = System.IO.Path.Combine(resultFoldName, contextName);

            Directory.CreateDirectory(sourcesFoldPath);

            string classesFileName = System.IO.Path.Combine(sourcesFoldPath, className + ".cs");

            using (TextWriter writer = File.CreateText(classesFileName))
            {
                string blokIndent = "";

                writer.WriteLine("using System;");
                writer.WriteLine("using System.Linq;");
                writer.WriteLine("using System.Text;");
                writer.WriteLine("using System.Threading.Tasks;");
                writer.WriteLine("using Repository.Pattern.Ef6;");
                writer.WriteLine("");
                writer.WriteLine("namespace " + schema.SchemaNamespace() + ".EntityModel");
                writer.WriteLine("{");
                blokIndent += TAB_INDENT1;
                writer.WriteLine(blokIndent + "// " + tableName + " : Declaration of the " + className);
                writer.WriteLine(blokIndent + "public class " + className + " : Entity");
                writer.WriteLine(blokIndent + "{");

                CreateEntityClassBodyBlock(writer, tableInfo, blokIndent);

                writer.WriteLine(blokIndent + "}");
                writer.WriteLine("");
                writer.WriteLine("}");
            }
        }

        private static void CreateEntityClassBodyBlock(TextWriter textWriter, TableDefInfo tableInfo, string blokIndent)
        {
            string className = TableDefInfo.ClassName(m_ConfigEntityNames, tableInfo.CodeFirstEntityName());

            blokIndent += TAB_INDENT1;

            textWriter.WriteLine(blokIndent + "public " + className + "()");
            textWriter.WriteLine(blokIndent + "{");
            textWriter.WriteLine(blokIndent + "}");
            textWriter.WriteLine("");

            CreateEntityClassColumnsBlock(textWriter, tableInfo, blokIndent);
        }

        private static void CreateEntityClassColumnsBlock(TextWriter textWriter, TableDefInfo tableInfo, string blokIndent)
        {
            IList<FieldDefInfo> columnList = tableInfo.TableColumnsVersion(m_numDataVers);

            foreach (FieldDefInfo columnInfo in columnList)
            {
                string columnName = tableInfo.ClassColumnName(columnInfo);
				if (columnInfo.IsAutoIncrement ()) {
					columnName = tableInfo.ClassColumnNameId();
				}

                int columnType = columnInfo.m_nType;

                int columnMaxx = columnInfo.DbColumnSize();

                bool columnNull = columnInfo.DbColumnNull();

                string propertyName = columnName.ConvertNameToCamel();

                string propertyType = DBPlatform.EntityConvertDataType(columnType, columnMaxx, !columnNull);

                textWriter.WriteLine(blokIndent + "public " + propertyType + " " + propertyName + " { get; set; }");
            }
        }

        private static void CreateConfigsClassTableBlock(TextWriter textWriter, TableDefInfo tableInfo, string blokIndent)
        {
            string tableName = tableInfo.Name();

            string className = TableDefInfo.ClassName(m_ConfigEntityNames, tableInfo.CodeFirstEntityName());

            blokIndent += TAB_INDENT1;
            textWriter.WriteLine(blokIndent + "// " + tableName + " : Declaration of the " + className);
            textWriter.WriteLine(blokIndent + "public class " + className + "Configuration : EntityTypeConfiguration<" + className + ">");
            textWriter.WriteLine(blokIndent + "{");

            CreateConfigsClassTableDeclar(textWriter, tableInfo, blokIndent);

            textWriter.WriteLine(blokIndent + "}");
        }

        private static void CreateConfigsClassTableDeclar(TextWriter textWriter, TableDefInfo tableInfo, string blokIndent)
        {
            string className = TableDefInfo.ClassName(m_ConfigEntityNames, tableInfo.CodeFirstEntityName());

            blokIndent += TAB_INDENT1;
            textWriter.WriteLine(blokIndent + "public " + className + "Configuration()");
            textWriter.WriteLine(blokIndent + "{");

            CreateConfigsClassColumnsBlock(textWriter, tableInfo, blokIndent);

            textWriter.WriteLine(blokIndent + "}");
        }

        private static void CreateConfigsClassColumnsBlock(TextWriter textWriter, TableDefInfo tableInfo, string blokIndent)
        {
            string tableName = tableInfo.Name();

            blokIndent += TAB_INDENT1;
            textWriter.WriteLine(blokIndent + "ToTable(\"" + tableName + "\");");

            IList<string> xpkcolList = tableInfo.TableColumnsPrimary();

            string keyNames = "";

            foreach (string columnName in xpkcolList)
            {
                string propertyName = columnName.ConvertNameToCamel();

                keyNames += "p." + propertyName + ", ";
            }
            textWriter.WriteLine(blokIndent + "HasKey(p => new { " + keyNames.TrimEnd(DBConstants.TRIM_CHARS) + " });");

            IList<FieldDefInfo> columnList = tableInfo.TableColumnsVersion(m_numDataVers);

            foreach (FieldDefInfo columnInfo in columnList)
            {
                string columnName = tableInfo.ClassColumnName(columnInfo);

                string propertyName = columnName.ConvertNameToCamel();

                textWriter.WriteLine(blokIndent + "Property(d => d." + propertyName + ").HasColumnName(\"" + columnName + "\");");
            }
        }

        public static void CreateContextClassFile(BaseSchemaManager schema, string contextName, IList<TableDefInfo> tableList, string resultFileName)
        {
            using (TextWriter writer = File.CreateText(resultFileName))
            {
                string blokIndent = "";

                writer.WriteLine("using System;");
                writer.WriteLine("using System.Linq;");
                writer.WriteLine("using System.Text;");
                writer.WriteLine("using System.Threading.Tasks;");
                writer.WriteLine("using System.Data.Entity;");
                writer.WriteLine("using " + schema.SchemaNamespace() + ".EntityModel;");
                writer.WriteLine("using " + schema.SchemaNamespace() + ".EntityConfiguration;");
                writer.WriteLine("");
                writer.WriteLine("namespace " + schema.SchemaNamespace() + ".EntityContext");
                writer.WriteLine("{");

                CreateContextClassBlock(writer, tableList, blokIndent, contextName);

                writer.WriteLine(blokIndent + "}");
            }

        }

        public static void CreateContextClassTableBlock(TextWriter textWriter, TableDefInfo tableInfo, string blokIndent, string contextName)
        {
            string className = TableDefInfo.ClassName(m_ConfigEntityNames, tableInfo.CodeFirstEntityName());

            blokIndent += TAB_INDENT1;

            textWriter.WriteLine(blokIndent + "public DbSet<" + className + "> " + className + " { get; set; }");
            textWriter.WriteLine("");
        }

        public static void CreateContextClassModelBlock(TextWriter textWriter, IList<TableDefInfo> tableList, string blokIndent, string contextName)
        {
            blokIndent += TAB_INDENT1;

            textWriter.WriteLine(blokIndent + "protected override void OnModelCreating");
            textWriter.WriteLine(blokIndent + TAB_INDENT1 + "(DbModelBuilder modelBuilder)");
            textWriter.WriteLine(blokIndent + "{");

            textWriter.WriteLine(blokIndent + "#region " + contextName.ConvertNameToCamel() + ".Tables");

            foreach (TableDefInfo tableDef in tableList)
            {
                CreateContextClassModelColumnsBlock(textWriter, tableDef, blokIndent);
            }

            textWriter.WriteLine(blokIndent + "#endregion");

            textWriter.WriteLine(blokIndent + "}");
        }

        private static void CreateContextClassModelColumnsBlock(TextWriter textWriter, TableDefInfo tableInfo, string blokIndent)
        {
            string className = TableDefInfo.ClassName(m_ConfigEntityNames, tableInfo.CodeFirstEntityName());

            blokIndent += TAB_INDENT1;

            textWriter.WriteLine(blokIndent + "modelBuilder.Configurations.Add(new " + className + "Configuration());");

        }
    }
}
