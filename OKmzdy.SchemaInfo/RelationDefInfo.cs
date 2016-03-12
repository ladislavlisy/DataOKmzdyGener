using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.SqlSchemaInfo
{
    public class RelationDefInfo
    {
	    private IList<RelationFieldDef> m_DaoRelationField;
	    public string m_strName;
	    public string m_strTable;
	    public string m_strForeignTable;
	    public int m_lAttributes;
	    public int m_nFields;

        public RelationDefInfo(string lpszName, string lpszForeignTable, string lpszRelTable)
        {
            m_DaoRelationField = new List<RelationFieldDef>();
	        m_strName = lpszName;
	        m_strTable = lpszRelTable;
	        m_strForeignTable = lpszForeignTable;
	        m_lAttributes = 0;
	        m_nFields = 0;
        }

        internal RelationFieldDef AppendField(string lpszName)
        {
            RelationFieldDef fieldInfo = new RelationFieldDef(lpszName, lpszName);

            m_DaoRelationField.Add(fieldInfo);
            m_nFields++;

            return fieldInfo;
        }

        internal RelationFieldDef AppendForeignField(string lpszForeignName, string lpszRelName)
        {
            RelationFieldDef fieldInfo = new RelationFieldDef(lpszForeignName, lpszRelName);

            m_DaoRelationField.Add(fieldInfo);
            m_nFields++;

            return fieldInfo;
        }

        public string CreateTableRelationSQL(int dbPlatform, bool addComma, bool addNewLine)
        {
            string strFieldName = CreateTableRelationFieldInfo(dbPlatform);
            if (strFieldName != DBConstants.EMPTY_STRING)
            {
                if (addComma)
                {
                    strFieldName += ",";
                }
                if (addNewLine)
                {
                    strFieldName += DBConstants.NEW_LINE_STR;
                }
            }
            return strFieldName;
        }

        public string AlterTableRelationSQL(int dbPlatform)
        {
            string strFieldName = DBConstants.EMPTY_STRING;

            if (DBPlatform.IsMsJetType(dbPlatform))
            {
                strFieldName = AlterTableCreateFieldsInfo(DBConstants.EMPTY_STRING, DBConstants.EMPTY_STRING);
            }
            else if (DBPlatform.IsMsSQLType(dbPlatform))
            {
                strFieldName = AlterTableCreateFieldsInfo(DBConstants.EMPTY_STRING, DBConstants.EMPTY_STRING);
            }
            else if (DBPlatform.IsOracleType(dbPlatform))
            {
                strFieldName = AlterTableCreateFieldsInfo("(", ")");
            }
            else if (DBPlatform.IsSQLiteType(dbPlatform))
            {
                strFieldName = DBConstants.EMPTY_STRING;
            }
            return strFieldName;
        }

        private string CreateTableRelationFieldInfo(int dbPlatform)
        {
            string sqlFieldsList = DBConstants.EMPTY_STRING;

            if (DBPlatform.IsMsJetType(dbPlatform))
            {
                sqlFieldsList = BaseCreateRelationFieldInfo();
            }
            else if (DBPlatform.IsMsSQLType(dbPlatform))
            {
                sqlFieldsList = BaseCreateRelationFieldInfo();
            }
            else if (DBPlatform.IsOracleType(dbPlatform))
            {
                sqlFieldsList = BaseCreateRelationFieldInfo();
            }
            else if (DBPlatform.IsSQLiteType(dbPlatform))
            {
                sqlFieldsList = SqliteCreateRelationFieldInfo();
            }
            return sqlFieldsList;
        }

        private string BaseCreateRelationFieldInfo()
        {
            return DBConstants.EMPTY_STRING;
        }

        private string SqliteCreateRelationFieldInfo()
        {
            string strNames = CreateFieldsListInfo();
            string strFNames = CreateForeignFieldsListInfo();

            string strSQL = ("");
            strSQL += ("FOREIGN KEY(");
            strSQL += strFNames;
	        strSQL += (") REFERENCES ");
	        strSQL += m_strTable;  
	        strSQL += ("(");
            strSQL += strNames;
	        strSQL += (")");
	        return strSQL;
        }

        internal string CreateFieldsListInfo()
        {
            string strNames = "";
            foreach (var field in m_DaoRelationField)
            {
                strNames += field.m_strName;
                strNames += (",");
            }
            string retNames = strNames.TrimEnd(DBConstants.TRIM_CHARS);
            return retNames;
        }

        internal string CreateForeignFieldsListInfo()
        {
            string strFNames = "";
            foreach (var field in m_DaoRelationField)
            {
                strFNames += field.m_strForeignName;
                strFNames += (",");
            }
            string retFNames = strFNames.TrimEnd(DBConstants.TRIM_CHARS);
            return retFNames;
        }

        internal string AlterTableCreateFieldsInfo(string addBegin, string addClose)
        {
            string strNames = CreateFieldsListInfo();
            string strFNames = CreateForeignFieldsListInfo();

	        string strSQL = ("ALTER TABLE ");
	        strSQL += m_strForeignTable;
	        strSQL += (" ADD ");
            strSQL += addBegin;
	        strSQL += (" CONSTRAINT ");

            strSQL += m_strName;
            strSQL += (" FOREIGN KEY (");
	        strSQL += strFNames;
	        strSQL += (") REFERENCES ");
	        strSQL += m_strTable;  
	        strSQL += (" (");
	        strSQL += strNames;
	        strSQL += (") ");
	        strSQL += addClose;
	        return strSQL;
        }

        internal void Delete()
        {
            m_DaoRelationField.Clear();
        }

        public string InfoName()
        {
            return m_strTable + "::" + m_strName;
        }

        internal IList<string> DeepRelationsList(IList<TableDefInfo> tables, IList<string> agrList)
        {
            TableDefInfo tableDef = tables.FirstOrDefault((t) => (t.Name().Equals(m_strTable)));

            if (tableDef == null)
            {
                return agrList;
            }
            return tableDef.DeepRelationsList(agrList, tables, true);
        }
    }
}
