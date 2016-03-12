using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

namespace OKmzdy.SqlSchemaInfo
{
    public class TableDefInfo
    {
        protected const string NEW_LINE_STR = DBConstants.NEW_LINE_STR;
        protected const int DB_SINGLE = DBConstants.DB_SINGLE;
        protected const int DB_TEXT = DBConstants.DB_TEXT;
        protected const int DB_BOOLEAN = DBConstants.DB_BOOLEAN;
        protected const int DB_BYTE = DBConstants.DB_BYTE;
        protected const int DB_CURRENCY = DBConstants.DB_CURRENCY;
        protected const int DB_DATE = DBConstants.DB_DATE;
        protected const int DB_DATETIME = DBConstants.DB_DATETIME;
        protected const int DB_DOUBLE = DBConstants.DB_DOUBLE;
        protected const int DB_INTEGER = DBConstants.DB_INTEGER;
        protected const int DB_LONG = DBConstants.DB_LONG;
        protected const int DB_LONGBINARY = DBConstants.DB_LONGBINARY;
        protected const int DB_MEMO = DBConstants.DB_MEMO;
        protected const int DB_GUID = DBConstants.DB_GUID;

        protected static bool dbNotNullFieldOption = DBConstants.dbNotNullFieldOption;
        protected static bool dbNullFieldOption = DBConstants.dbNullFieldOption;

        protected static int dbFixedField = DBConstants.dbFixedField;
        protected static int dbUpdatableField = DBConstants.dbUpdatableField;
        protected static int dbAutoIncrField = DBConstants.dbAutoIncrField;

        protected IList<FieldDefInfo> m_TableFields;
        protected IndexDefInfo m_PKConstraint;
        protected IList<IndexDefInfo> m_TableIndexs;
        protected IList<RelationDefInfo> m_TableRelations;
	    protected int m_nFields;
        protected string m_strOwnerName;
        protected string m_strUsersName;
        protected string m_strName;
        protected UInt32 m_VersFrom = 0;
        protected UInt32 m_VersDrop = 9999;

        public bool IsValidInVersion(UInt32 versCreate)
        {
            return (m_VersFrom <= versCreate && versCreate < m_VersDrop);
        }

        public string Name()
        {
            return m_strName;
        }

        public string EntityName()
        {
            return m_strName.Underscore().Camelize();
        }

        public string CodeFirstEntityName()
        {
            return m_strName.ConvertNameToCamel();
        }

        public void ReNameTable(string tableName)
        {
            m_strName = tableName;
        }

        public void ReNameColumn(string oldName, string newName)
        {
            foreach (var column in m_TableFields)
            {
                if (column.ColumnName().Equals(oldName))
                {
                    column.ReNameColumn(newName);
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            TableDefInfo objAsDef = obj as TableDefInfo;
            if (objAsDef == null) return false;
            else return Equals(objAsDef);
        }
        public int SortByNameAscending(string name1, string name2)
        {
            return name1.CompareTo(name2);
        }

        // Default comparer for Part type.
        public int CompareTo(TableDefInfo compareDef)
        {
            // A null value means that this object is greater.
            if (compareDef == null)
                return 1;

            else
                return this.m_strName.CompareTo(compareDef.m_strName);
        }
        public override int GetHashCode()
        {
            return m_strName.GetHashCode();
        }
        public bool Equals(TableDefInfo other)
        {
            if (other == null) return false;
            return (this.m_strName.Equals(other.m_strName));
        }

        //public static bool operator==(TableDefInfo first, TableDefInfo last)
        //{
        //    return first.Equals(last);
        //}

        //public static bool operator!=(TableDefInfo first, TableDefInfo last)
        //{
        //    return !first.Equals(last);
        //}

        public string InfoName()
        {
            return m_strName;
        }

        public TableDefInfo(string lpszOwnerName, string lpszUsersName, string lpszTableName, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            this.m_strOwnerName = lpszOwnerName;
            this.m_strUsersName = lpszUsersName;
            this.m_TableFields = new List<FieldDefInfo>();
            m_PKConstraint = null;
            this.m_TableIndexs = new List<IndexDefInfo>();
            this.m_TableRelations = new List<RelationDefInfo>();
            this.m_strName = lpszTableName;
            this.m_VersFrom = versFrom;
            this.m_VersDrop = versDrop;
        }

        public IList<FieldDefInfo> TableColumnsVersion(UInt32 versCreate)
        {
            return m_TableFields.Where((c) => (c.IsValidInVersion(versCreate))).ToList();
        }

        public IList<string> TableColumnsPrimary()
        {
            if (m_PKConstraint != null)
            {
                return m_PKConstraint.CreateFieldsNamesArray().Select((x) => ClassColumnName(x)).ToList();
            }
            return new List<string>();
        }

        public string ClassColumnName(FieldDefInfo columnInfo)
        {
            return ClassColumnName(columnInfo.ColumnName());
        }

		public string ClassColumnNameId()
		{
			return ClassColumnName("id");
		}

        virtual public string ClassColumnName(string columnName)
        {
            return columnName;
        }

        public static string ClassName(Tuple<string, string>[] changeNames, string tableName)
        {
            return changeNames.Aggregate(tableName, (agr, x) => agr.Replace(x.Item1, x.Item2));
        }

        protected static string PropertyName(Tuple<string, string>[] changeNames, string columnName)
        {
            Tuple<string, string> propertyName = changeNames.FirstOrDefault((x) => (x.Item1.Equals(columnName)));
            if (propertyName == null)
            {
                return columnName;
            }
            return propertyName.Item2;
        }

        public IList<FieldDefInfo> TableColumns()
        {
            return m_TableFields;
        }

        public IndexDefInfo IndexPK() 
        {
            return m_PKConstraint;
        }

        public IList<IndexDefInfo> IndexesNonPK()
        {
            return m_TableIndexs;
        }
        public IList<RelationDefInfo> Relations()
        {
            return m_TableRelations;
        }

        private FieldDefInfo FieldAppend(FieldDefInfo fieldInfo)
        {
            m_TableFields.Add(fieldInfo);
            m_nFields++;

            return fieldInfo;
        }

        private FieldDefInfo FieldInsertBeg(FieldDefInfo fieldInfo)
        {
            m_TableFields.Insert(0, fieldInfo);
            m_nFields++;

            return fieldInfo;
        }

        private FieldDefInfo FieldInsertIdx(FieldDefInfo fieldInfo, int index)
        {
            m_TableFields.Insert(Math.Min(index, m_nFields), fieldInfo);
            m_nFields++;

            return fieldInfo;
        }

        private IndexDefInfo IndexAppend(IndexDefInfo indexInfo)
        {
            m_TableIndexs.Add(indexInfo);

            return indexInfo;
        }

        private RelationDefInfo RelationAppend(RelationDefInfo relationInfo)
        {
            m_TableRelations.Add(relationInfo);

            return relationInfo;
        }

        internal FieldDefInfo CreateFieldInfo(string lpszName, int nType, bool bNullOption, UInt32 versFrom, UInt32 versDrop)
        {
            FieldDefInfo fieldInfo = new FieldDefInfo(versFrom, versDrop);
            fieldInfo.m_strName = lpszName;
            fieldInfo.m_nType = nType;

            fieldInfo.m_bAllowZeroLength = false;
            fieldInfo.m_bRequired = !bNullOption;
            fieldInfo.m_lCollatingOrder = 0;
            fieldInfo.m_nOrdinalPosition = 0;
            fieldInfo.m_strDefaultValue = "";
            fieldInfo.m_strForeignName = "";
            fieldInfo.m_strSourceField = "";
            fieldInfo.m_strSourceTable = "";
            fieldInfo.m_strValidationRule = "";
            fieldInfo.m_strValidationText = "";
            fieldInfo.m_lAttributes = dbFixedField | dbUpdatableField;
            fieldInfo.m_lSize = FieldSize(nType);
            fieldInfo.m_strDefaultValue = FieldDefaultValue(nType, bNullOption);
            return (fieldInfo);
        }

        internal FieldDefInfo CreateField(string lpszName, int nType, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            FieldDefInfo fieldInfo = CreateFieldInfo(lpszName, nType, bNullOption, versFrom, versDrop);

            return FieldAppend(fieldInfo);
        }

        internal FieldDefInfo InsertField(int index, string lpszName, int nType, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            FieldDefInfo fieldInfo = CreateFieldInfo(lpszName, nType, bNullOption, versFrom, versDrop);

            return FieldInsertIdx(fieldInfo, index);
        }

        internal FieldDefInfo CreateFTEXTInfo(string lpszName, int nType, int size, bool bNullOption, UInt32 versFrom, UInt32 versDrop)
        {
            FieldDefInfo fieldInfo = new FieldDefInfo(versFrom, versDrop);
            fieldInfo.m_strName = lpszName;
	        fieldInfo.m_nType   = nType;

	        fieldInfo.m_lAttributes = dbUpdatableField;
	        fieldInfo.m_bAllowZeroLength = true;
	        fieldInfo.m_lSize = size ;
	        fieldInfo.m_bRequired = !bNullOption;
	        fieldInfo.m_lCollatingOrder = 0;
	        fieldInfo.m_nOrdinalPosition = 0;
	        fieldInfo.m_strDefaultValue = "";
	        fieldInfo.m_strForeignName = "";
	        fieldInfo.m_strSourceField = "";
	        fieldInfo.m_strSourceTable = "";
	        fieldInfo.m_strValidationRule = "";
	        fieldInfo.m_strValidationText = "";

            return (fieldInfo);
        }

        internal FieldDefInfo CreateFTEXT(string lpszName, int nType, int size, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            FieldDefInfo fieldInfo = CreateFTEXTInfo(lpszName, nType, size, bNullOption, versFrom, versDrop);

            return FieldAppend(fieldInfo);
        }

        internal FieldDefInfo InsertFTEXT(int index, string lpszName, int nType, int size, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            FieldDefInfo fieldInfo = CreateFTEXTInfo(lpszName, nType, size, bNullOption, versFrom, versDrop);

            return FieldInsertIdx(fieldInfo, index);
        }

        internal FieldDefInfo CreateGDATEInfo(string lpszName, int nType, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            FieldDefInfo fieldInfo = new FieldDefInfo(versFrom, versDrop);
	        fieldInfo.m_strName = lpszName;
	        fieldInfo.m_nType = nType;

	        fieldInfo.m_bAllowZeroLength = false;
	        fieldInfo.m_bRequired = !bNullOption;
	        fieldInfo.m_lCollatingOrder = 0;
	        fieldInfo.m_nOrdinalPosition = 0;
	        fieldInfo.m_strDefaultValue = "";
	        fieldInfo.m_strForeignName = "";
	        fieldInfo.m_strSourceField = "";
	        fieldInfo.m_strSourceTable = "";
	        fieldInfo.m_strValidationRule = "";
	        fieldInfo.m_strValidationText = "";
	        fieldInfo.m_lAttributes = dbFixedField | dbUpdatableField;
            fieldInfo.m_lSize = FieldSize(nType);
            if (fieldInfo.m_bRequired)
	        {
                fieldInfo.m_strDefaultValue = "*";
	        }

            return (fieldInfo);
        }

        internal FieldDefInfo CreateGDATE(string lpszName, int nType, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            FieldDefInfo fieldInfo = CreateGDATEInfo(lpszName, nType, bNullOption, versFrom, versDrop);

            return FieldAppend(fieldInfo);
        }

        internal FieldDefInfo InsertGDATE(int index, string lpszName, int nType, bool bNullOption, UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            FieldDefInfo fieldInfo = CreateGDATEInfo(lpszName, nType, bNullOption, versFrom, versDrop);

            return FieldInsertIdx(fieldInfo, index);
        }

        internal FieldDefInfo CreateFAUTO(string lpszName, int nType)
        {
            FieldDefInfo fieldInfo = new FieldDefInfo();
	        fieldInfo.m_strName = lpszName;
	        fieldInfo.m_nType   = nType;

	        fieldInfo.m_bAllowZeroLength = false;
	        fieldInfo.m_bRequired = true;
	        fieldInfo.m_lCollatingOrder = 0;
	        fieldInfo.m_nOrdinalPosition = 0;
	        fieldInfo.m_strDefaultValue = "";
	        fieldInfo.m_strForeignName = "";
	        fieldInfo.m_strSourceField = "";
	        fieldInfo.m_strSourceTable = "";
	        fieldInfo.m_strValidationRule = "";
	        fieldInfo.m_strValidationText = "";
	        fieldInfo.m_lAttributes = dbFixedField |  dbAutoIncrField | dbUpdatableField;
		    fieldInfo.m_lSize = FieldSize(nType) ;

            return FieldInsertBeg(fieldInfo);
        }

        internal IndexDefInfo CreateIndex(string lpszName, bool bUnique = false)
        {
            IndexDefInfo indexInfo = new IndexDefInfo(lpszName, m_strName, false);
            indexInfo.m_bUnique = bUnique;

            return IndexAppend(indexInfo);
        }

        internal RelationDefInfo CreateRelation(string lpszName, string lpszRelTable)
        {
            RelationDefInfo indexInfo = new RelationDefInfo(lpszName, m_strName, lpszRelTable);

            return RelationAppend(indexInfo);
        }

        private int FieldSize(int nType)
        {
            int fieldInfoSize = 0;
            switch (nType)
            {
                case DB_BOOLEAN:
                    fieldInfoSize = 1;
                    break;
                case DB_BYTE:
                    fieldInfoSize = 1;
                    break;
                case DB_INTEGER:
                    fieldInfoSize = 2;
                    break;
                case DB_LONG:
                    fieldInfoSize = 4;
                    break;
                case DB_CURRENCY:
                    fieldInfoSize = 8;
                    break;
                case DB_SINGLE:
                    fieldInfoSize = 4;
                    break;
                case DB_DOUBLE:
                    fieldInfoSize = 8;
                    break;
                case DB_DATE:
                    fieldInfoSize = 8;
                    break;
                case DB_LONGBINARY:
                    fieldInfoSize = 0;
                    break;
                default:
                    fieldInfoSize = 0;
                    break;
            }
            return fieldInfoSize;
        }

        private string FieldDefaultValue(int nType, bool bNullOption)
        {
            string fieldInfoDefaultValue = "";
            switch (nType)
            {
                case DB_BOOLEAN:
                    if (!bNullOption)
                    {
                        fieldInfoDefaultValue = "0";
                    }
                    break;
                case DB_BYTE:
                    if (!bNullOption)
                    {
                        fieldInfoDefaultValue = "0";
                    }
                    break;
                case DB_INTEGER:
                    if (!bNullOption)
                    {
                        fieldInfoDefaultValue = "0";
                    }
                    break;
                case DB_LONG:
                    if (!bNullOption)
                    {
                        fieldInfoDefaultValue = "0";
                    }
                    break;
                case DB_CURRENCY:
                    break;
                case DB_SINGLE:
                    break;
                case DB_DOUBLE:
                    break;
                case DB_DATE:
                    break;
                case DB_LONGBINARY:
                    break;
                default:
                    break;
            }
            return fieldInfoDefaultValue;
        }

        internal string CreateTableSQL(int dbPlatform, UInt32 versCreate)
        {
		    string strFieldNames = DbColsDefinition(dbPlatform, versCreate);
		    string strSQL = ("CREATE TABLE ");
		    strSQL += m_strName;
		    strSQL += " ";
		    strSQL += strFieldNames;

            return strSQL;
        }

        internal string CreateTableSynonymSQL(int dbPlatform)
        {
            string strSQL = ("CREATE SYNONYM ");
            strSQL += m_strUsersName;
            strSQL += (".");
            strSQL += m_strName;
            strSQL += (" FOR ");
            strSQL += m_strOwnerName;
            strSQL += (".");
            strSQL += m_strName;

            return strSQL;
        }

        internal string CreateTableSecuritySQL(int dbPlatform)
        {
            string strSQL = ("GRANT SELECT, INSERT, UPDATE, DELETE ON ");
            strSQL += m_strOwnerName;
            strSQL += (".");
            strSQL += m_strName;
            strSQL += (" TO ");
            strSQL += m_strUsersName;	

            return strSQL;
        }

        internal string CreateSeqSQL(int dbPlatform)
        {
			string strSQL = ("CREATE SEQUENCE SEQ_");
			strSQL += m_strName;
			strSQL += (" INCREMENT BY 1 START WITH 1");

            return strSQL;
        }

        internal string CreateSeqSynonymSQL(int dbPlatform)
        {
			string strSQL = ("CREATE SYNONYM ");
			strSQL += m_strUsersName;	
			strSQL += (".SEQ_");
			strSQL += m_strName;
			strSQL += (" FOR ");
			strSQL += 	m_strOwnerName;
			strSQL += (".SEQ_");
			strSQL += m_strName;

            return strSQL;
        }

        internal string CreateSeqSecuritySQL(int dbPlatform)
        {
            string strSQL = ("GRANT SELECT ON ");
            strSQL += m_strOwnerName;
            strSQL += (".SEQ_");
            strSQL += m_strName;
            strSQL += (" TO ");
            strSQL += m_strUsersName;
            
            return strSQL;
        }

        internal string CreateBindDefaultSQL(int dbPlatform, UInt32 versCreate)
        {
		    string strSQL = "";

            foreach (var field in m_TableFields)
            {
                if (field.IsValidInVersion(versCreate))
                {
                    string strDefaultSQL;
                    bool bRequiredDefault = DBPlatform.DefaultBindRequired(field.m_lAttributes);

                    if (field.m_bRequired && bRequiredDefault)
                    {
                        if (BindDefaultDataType(field.m_nType))
                        {
                            strDefaultSQL = BindDefaultDataTypeSql(m_strName, field.m_strName);
                            strSQL += (strDefaultSQL);
                            strSQL += DBConstants.NEW_LINE_STR;
                        }
                    }
                }
            }

            return strSQL;
        }

        private int GetSynonymCount(int dbPlatform, DbConnection conn, string strUsersName, string strObjectName)
        {
            if (DBPlatform.IsMsJetType(dbPlatform))
            {
                return 0;
            }
            else if (DBPlatform.IsMsSQLType(dbPlatform))
            {
                return 0;
            }
            else if (DBPlatform.IsOracleType(dbPlatform))
            {
                return 0;
            }
            else if (DBPlatform.IsSQLiteType(dbPlatform))
            {
                return 0;
            }
            return 0;
        }

        private static string DbConvertDataType(int dbPlatform, int nType, int nSize)
        {
            string strFieldType = "";
            if (DBPlatform.IsMsJetType(dbPlatform))
            {
                strFieldType = DBPlatform.MsJetConvertDataType(nType, nSize);
            }
            else if (DBPlatform.IsMsSQLType(dbPlatform))
            {
                strFieldType = DBPlatform.MsSQLConvertDataType(nType, nSize);
            }
            else if (DBPlatform.IsOracleType(dbPlatform))
            {
                strFieldType = DBPlatform.OracleConvertDataType(nType, nSize);
            }
            else if (DBPlatform.IsSQLiteType(dbPlatform))
            {
                strFieldType = DBPlatform.SqliteConvertDataType(nType, nSize);
            }
            return strFieldType;
        }

        private string DbIdentity(int dbPlatform, int lAttributes)
        {
            string strDbIdentity = ""; 
            bool identityColumn = DBPlatform.AutoIncrField(lAttributes);
            if (identityColumn)
            {
                if (DBPlatform.IsMsJetType(dbPlatform))
                {
                    strDbIdentity = "IDENTITY ";
                }
                else if (DBPlatform.IsMsSQLType(dbPlatform))
                {
                    strDbIdentity = "IDENTITY(1,1) ";
                }
                else if (DBPlatform.IsOracleType(dbPlatform))
                {
                }
                else if (DBPlatform.IsSQLiteType(dbPlatform))
                {
                }
            }
            return strDbIdentity;
        }

        private string DbNullAndDefault(int dbPlatform, int nType, string strDefaultValue, bool bRequired, int lAttributes)
        {
            bool bColumnDefault = false;
            bool bFieldDefault = (strDefaultValue.Length != 0);

            bool bRequiredDefault = DBPlatform.DefaultBindRequired(lAttributes);

            string strFieldNames = "";
            if (DBPlatform.IsMsJetType(dbPlatform))
            {
                bColumnDefault = true;
            }
            else if (DBPlatform.IsMsSQLType(dbPlatform))
            {
                bColumnDefault = false;
            }
            else if (DBPlatform.IsOracleType(dbPlatform))
            {
                bColumnDefault = true;
            }
            else if (DBPlatform.IsSQLiteType(dbPlatform))
            {
                bColumnDefault = true;
            }

            if (bColumnDefault)
            {
                if (bRequired && bRequiredDefault)
                {
                    switch (nType)
                    {
                        case DB_BOOLEAN:
                        case DB_BYTE:
                        case DB_INTEGER:
                        case DB_LONG:
                            strFieldNames += DBPlatform.NumberDefault(dbPlatform);
                            break;
                        case DB_DATE:
                            strFieldNames += DBPlatform.GDateDefault(dbPlatform);
                            break;
                    }
                }
            }
            if (bRequired)
            {
                strFieldNames += " NOT NULL";
            }
            else
            {
                strFieldNames += " NULL";
            }
            return strFieldNames;
        }

        private string DbPKsDefinition(int dbPlatform)
        {
            string strFieldNames = "";

            if (m_PKConstraint != null)
            {
                strFieldNames += m_PKConstraint.CreateConstraintSQL(dbPlatform, true, true);
            }
            return strFieldNames;
        }

        private string DbRelsDefinition(int dbPlatform)
        {
            string strFieldNames = "";

            foreach (var item in m_TableRelations)
            {
                strFieldNames += item.CreateTableRelationSQL(dbPlatform, true, true);
            }
            return strFieldNames;
        }

        private string DbColsDefinition(int dbPlatform, UInt32 versCreate)
        {
            string strFieldNames = "(";
            foreach (var field in m_TableFields)
            {
                if (field.IsValidInVersion(versCreate))
                {
                    strFieldNames += NEW_LINE_STR;
                    strFieldNames += field.m_strName;
                    strFieldNames += " ";
                    strFieldNames += DbConvertDataType(dbPlatform, field.m_nType, field.m_lSize);
                    strFieldNames += " ";
                    strFieldNames += DbIdentity(dbPlatform, field.m_lAttributes);
                    strFieldNames += DbNullAndDefault(dbPlatform, field.m_nType, field.m_strDefaultValue, field.m_bRequired, field.m_lAttributes);

                    strFieldNames += ",";
                }
            }
            strFieldNames += NEW_LINE_STR;
            strFieldNames += DbRelsDefinition(dbPlatform);
            strFieldNames += DbPKsDefinition(dbPlatform);

            string retTableSql = strFieldNames.TrimEnd(DBConstants.TRIM_CHARS);
            retTableSql += " )";
            retTableSql += NEW_LINE_STR;
            return retTableSql;
        }

        private bool DbSequence(int dbPlatform)
        {
            bool bOracleSeq = DBPlatform.IsOracleType(dbPlatform);
            
            bool bSequence = false;

            foreach (var field in m_TableFields)
            {
                int lAutoIncrField = (field.m_lAttributes & dbAutoIncrField);
                if (lAutoIncrField == dbAutoIncrField)
	            {
                    bSequence = bOracleSeq;
                }
            }

            return bSequence;
        }

        private bool DbSynonyms(int dbPlatform)
        {
            bool bOracleSyn = DBPlatform.IsOracleType(dbPlatform);

            return bOracleSyn;
        }

        private bool DbSecurity(int dbPlatform)
        {
            bool bOracleSec = DBPlatform.IsOracleType(dbPlatform);

            return bOracleSec;
        }

        private bool DbBindColumns(int dbPlatform)
        {
            bool bBindColumns = DBPlatform.IsMsSQLType(dbPlatform);

            return bBindColumns;
        }

        private bool DbDefineRel(int dbPlatform)
        {
            bool bDbDefineRel = DBPlatform.IsSQLiteType(dbPlatform);

            return bDbDefineRel;
        }

        private static bool BindDefaultDataType(int nType)
        {
            bool bBindDefault = false;
			switch ( nType )
			{
			case DB_BOOLEAN :
			case DB_BYTE :
			case DB_INTEGER :
			case DB_LONG :
                bBindDefault = true;
				break;
			}
            return (bBindDefault);
        }

        private static string BindDefaultDataTypeSql(string strTableName, string strFieldName)
        {
            string strDefaultSQL = "sp_bindefault Cislo_Nula, '";
			strDefaultSQL += strTableName;
			strDefaultSQL += (".");
			strDefaultSQL += strFieldName;
			strDefaultSQL += ("'");
            return strDefaultSQL;
        }

        void Clear()
        {
            m_strName = "";
            m_TableFields.Clear();
            m_nFields = 0;
            m_PKConstraint = null;
            m_TableIndexs.Clear();
            m_TableRelations.Clear();
        }

        internal IndexDefInfo CreatePKConstraint(string lpszName)
        {
            string constraintName = lpszName + m_strName;

            m_PKConstraint = new IndexDefInfo(constraintName, m_strName, true);

            return m_PKConstraint;
        }

        internal IndexDefInfo AddTableIndex(string lpszName)
        {
            IndexDefInfo indexInfo = new IndexDefInfo(lpszName, m_strName, false);

	        return indexInfo;
        }

        public string CreateSelectCount()
        {
            string selectCountSql = "SELECT count(*) AS POCET FROM ";
            selectCountSql += m_strName;

            return selectCountSql;
        }

        public string CreateSelectCommand(UInt32 versCreate)
        {
            string sqlCommand = "SELECT ";

            sqlCommand += CreateColumnList(versCreate);

            sqlCommand += " FROM ";
            sqlCommand += m_strName;

            return sqlCommand;
        }

        public string CreateInsertSelectCommand(UInt32 versCreate)
        {
            string sqlCommand = "INSERT INTO ";

            sqlCommand += m_strName;

            sqlCommand += " (";
            sqlCommand += CreateColumnList(versCreate);
            sqlCommand += " ) VALUES (";
            sqlCommand += "SELECT ";
            sqlCommand += CreateColumnList(versCreate);
            sqlCommand += " FROM ";
            sqlCommand += m_strName;
            sqlCommand += " )";

            return sqlCommand;
        }

        private string CreateColumnList(UInt32 versCreate)
        {
            string columnsList = "";

            foreach (FieldDefInfo field in m_TableFields)
            {
                if (field.IsValidInVersion(versCreate))
                {
                    columnsList += field.m_strName;
                    columnsList += ", ";
                }
            }
            string columnListRet = columnsList.TrimEnd(DBConstants.TRIM_CHARS);

            return columnListRet;
        }


        public string InsertCommandWithParams(UInt32 versCreate)
        {
            string sqlCommand = "INSERT INTO ";

            sqlCommand += m_strName;

            sqlCommand += " (";
            sqlCommand += CreateColumnList(versCreate);
            sqlCommand += " ) VALUES (";
            sqlCommand += CreateParametrList(versCreate);
            sqlCommand += " )";

            return sqlCommand;
        }

        private string CreateParametrList(UInt32 versCreate)
        {
            string columnsList = "";

            foreach (FieldDefInfo field in m_TableFields)
            {
                if (field.IsValidInVersion(versCreate))
                {
                    columnsList += "@" + field.m_strName.Underscore().Camelize();
                    columnsList += ", ";
                }
            }
            string columnListRet = columnsList.TrimEnd(DBConstants.TRIM_CHARS);

            return columnListRet;
        }

        public string InsertCommandWithValues(UInt32 versCreate, DataRow values, int dbPlatform)
        {
            string sqlCommand = "INSERT INTO ";

            sqlCommand += m_strName;

            sqlCommand += " (";
            sqlCommand += CreateColumnList(versCreate);
            sqlCommand += " ) VALUES (";
            sqlCommand += CreateValueList(versCreate, values, dbPlatform);
            sqlCommand += " )";

            return sqlCommand;
        }

        private string CreateValueList(UInt32 versCreate, DataRow dataRow, int dbPlatform)
        {
            string columnsList = "";

            foreach (FieldDefInfo field in m_TableFields)
            {
                if (field.IsValidInVersion(versCreate))
                {
                    int typeColumn = field.m_nType;

                    bool appendValue = true;

                    string dataItem = dataRow[field.m_strName].ToString();

                    switch (typeColumn)
                    {
                        case DB_TEXT:
                        case DB_BOOLEAN:
                        case DB_BYTE:
                        case DB_INTEGER:
                        case DB_LONG:
                        case DB_CURRENCY:
                        case DB_SINGLE:
                        case DB_DOUBLE:
                        case DB_DATE:
                            break;
                        case DB_LONGBINARY:
                        default:
                            appendValue = false;
                            break;
                    }
                    string dataColumn = "";
                    if (dataItem.Length == 0)
                    {
                        dataColumn += "NULL";
                    }
                    else
                    {
                        switch (typeColumn)
                        {
                            case DB_BOOLEAN:
                                if (dataItem.CompareTo("False") == 0)
                                {
                                    dataColumn += "0";
                                }
                                else
                                {
                                    dataColumn += "1";
                                }
                                break;
                            case DB_BYTE:
                                dataColumn += dataItem;
                                break;
                            case DB_INTEGER:
                                dataColumn += dataItem;
                                break;
                            case DB_LONG:
                                dataColumn += dataItem;
                                break;
                            case DB_CURRENCY:
                                dataColumn += dataItem;
                                break;
                            case DB_SINGLE:
                                dataColumn += dataItem;
                                break;
                            case DB_DOUBLE:
                                dataColumn += dataItem;
                                break;
                            case DB_DATE:
                                dataColumn += DBPlatform.GDateValue(dbPlatform, DateTime.Parse(dataItem));
                                break;
                            case DB_LONGBINARY:
                                dataColumn += dataItem;
                                break;
                            case DB_TEXT:
                                dataColumn += "'";
                                dataColumn += dataItem;
                                dataColumn += "'";
                                break;
                            default:
                                dataColumn += dataItem;
                                break;
                        }
                    }
                    if (appendValue)
                    {
                        columnsList += dataColumn;
                        columnsList += ",";
                    }
                }
            }
            string columnListRet = columnsList.TrimEnd(DBConstants.TRIM_CHARS);

            return columnListRet;
        }

        public IList<string> DeepRelationsList(IList<string> agrList, IList<TableDefInfo> tables, bool addTableName)
        {
            IList<string> retList = agrList.ToList();
            if (addTableName)
            {
                retList = agrList.Concat(new string[] { m_strName }).ToList();
            }

            if (m_TableRelations.Count == 0)
            {
                return retList;
            }

            return m_TableRelations.Aggregate(retList, (agr, r) => r.DeepRelationsList(tables, agr));
        }
    }
}
