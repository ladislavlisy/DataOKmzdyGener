using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace OKmzdy.SqlSchemaInfo
{
    public abstract class BaseSchemaManager
    {
        protected IDictionary<string, TableDefInfo> ALL_TABLES_DICT = null;
        public string m_strOwnerName {  get; protected set; }
        public string m_strUsersName {  get; protected set; }
        public BaseSchemaManager(string lpszOwnerName, string lpszUsersName)
        {
            this.m_strOwnerName = lpszOwnerName;
            this.m_strUsersName = lpszUsersName;
        }
        public abstract IDictionary<string, TableDefInfo> CreateTablesDictionary();
        // Context List
        public abstract IList<TableDefInfo> CreateContextServiceList(string lpszOwnerName, string lpszUsersName);
        public abstract IList<TableDefInfo> CreateContextCompanyList(string lpszOwnerName, string lpszUsersName);
        public abstract IList<TableDefInfo> CreateContextOrganizList(string lpszOwnerName, string lpszUsersName);
        public abstract IList<TableDefInfo> CreateContextPersonaList(string lpszOwnerName, string lpszUsersName);
        public abstract IList<TableDefInfo> CreateContextPeriodsList(string lpszOwnerName, string lpszUsersName);
        public abstract IList<TableDefInfo> CreateContextToolSetList(string lpszOwnerName, string lpszUsersName);
        public abstract IList<TableDefInfo> CreateContextWageSetList(string lpszOwnerName, string lpszUsersName);
        public abstract IList<TableDefInfo> CreateContextTariffsList(string lpszOwnerName, string lpszUsersName);
        public abstract IList<TableDefInfo> CreateContextCurrSetList(string lpszOwnerName, string lpszUsersName);
        public abstract IList<TableDefInfo> CreateContextReportsList(string lpszOwnerName, string lpszUsersName);
        public abstract IList<TableDefInfo> CreateContextExportsList(string lpszOwnerName, string lpszUsersName);
        public abstract IList<TableDefInfo> CreateContextImportsList(string lpszOwnerName, string lpszUsersName);
        public abstract IList<TableDefInfo> CreateContextRepDataList(string lpszOwnerName, string lpszUsersName);

        // CreateDatabaseList
        public abstract IList<TableDefInfo> CreateImportsTableList(string lpszOwnerName, string lpszUsersName);

        public abstract IList<TableDefInfo> CreateServiceTableList(string lpszOwnerName, string lpszUsersName);

        public abstract IList<TableDefInfo> CreateCompanyTableList(string lpszOwnerName, string lpszUsersName);

        public abstract IList<TableDefInfo> CreateCopyDataTableList(string lpszOwnerName, string lpszUsersName);

        // CreateDatabaseNewList
        public abstract IList<TableDefInfo> CreateSubsetTableList(IList<string> filterList);

        public abstract string SchemaNamespace();

        public abstract string ContextName();

        public abstract string ContextFolder();

        public static IDictionary<string, IList<string>> SortedRelationsList(IList<TableDefInfo> copyInfo)
        {
            IDictionary<string, IList<string>> mapaRelationList = new Dictionary<string, IList<string>>();

            foreach (TableDefInfo tableDef in copyInfo)
            {
                IList<string> initRelationList = new List<string>();

                IList<string> retsRelationList = tableDef.DeepRelationsList(initRelationList, copyInfo, false);

                mapaRelationList.Add(tableDef.Name(), retsRelationList.Distinct().ToList());
            }
            return mapaRelationList;
        }

        public static IList<TableDefInfo> SortTabelListByRelations(IList<TableDefInfo> copyInfo, IDictionary<string, IList<string>> relationList)
        {
            List<TableDefInfo> sortInfo = copyInfo.ToList();

            sortInfo.Sort(delegate(TableDefInfo x, TableDefInfo y)
            {
                if (x.Name() == null && y.Name() == null)
                {
                    return 0;
                }
                else if (x.Name() == null)
                {
                    return -1;
                }
                else if (y.Name() == null)
                {
                    return 1;
                }
                else if (x.Equals(y))
                {
                    return 0;
                }
                else if (RelateTo(x, y, relationList))
                {
                    return 1;
                }
                else if (RelateTo(y, x, relationList))
                {
                    return -1;
                }
                return CompareToRelate(x, y, relationList);
            });
            return sortInfo;
        }

        private static int CompareToRelate(TableDefInfo tableX, TableDefInfo tableY, IDictionary<string, IList<string>> relationList)
        {
            IList<string> relationsX = null;

            IList<string> relationsY = null;

            relationList.TryGetValue(tableX.Name(), out relationsX);

            relationList.TryGetValue(tableY.Name(), out relationsY);

            if (relationsX == null && relationsY == null)
            {
                return 0;
            }
            else if (relationsX == null)
            {
                return -1;
            }
            else if (relationsY == null)
            {
                return 1;
            }
            else
            {
                int compareCount = relationsX.Count.CompareTo(relationsY.Count);
                if (compareCount == 0)
                {
                    return tableX.CompareTo(tableY);
                }
                else
                {
                    return compareCount;
                }
            }
        }

        public static bool RelateTo(TableDefInfo tableX, TableDefInfo tableY, IDictionary<string, IList<string>> relationList)
        {
            IList<string> relations = null;

            relationList.TryGetValue(tableX.Name(), out relations);

            if (relations == null) return false;

            string relatedTable = relations.FirstOrDefault((r) => (r.Equals(tableY.Name())));

            return (relatedTable != null);
        }

        public static void LogSortedTables(IList<TableDefInfo> sortInfo)
        {
            string resultFoldName = "..\\..\\..\\";

            string resultFileName = resultFoldName + ("sorted_tables.txt");

            using (TextWriter writer = File.CreateText(resultFileName))
            {
                foreach (TableDefInfo tableDef in sortInfo)
                {
                    writer.WriteLine("new TablesData.Table{0}Info(lpszOwnerName, lpszUsersName),", tableDef.Name().Underscore().Camelize());
                }
            }
        }

    }
}
