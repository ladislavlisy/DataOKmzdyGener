using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.SqlSchemaInfo
{
    public class IndexDefInfo
    {
        private IList<IndexFieldDefInfo> m_IndexFields;
        public string m_strName;
        public string m_strTable;
        private int m_nFields;
        public bool m_bUnique;
        public bool m_bPrimary;

        public IndexDefInfo()
        {
            m_IndexFields = new List<IndexFieldDefInfo>();
            m_strName = "";
            m_strTable = "";
            m_nFields = 0;
            m_bPrimary = false;
            m_bUnique = false;
        }

        public IndexDefInfo(string lpszName, string lpszTable, bool primary = false)
        {
            m_IndexFields = new List<IndexFieldDefInfo>();
            m_strName = lpszName;
            m_strTable = lpszTable;
            m_nFields = 0;
            m_bPrimary = primary;
            m_bUnique = false;
        }

        internal void AppendField(string lpszName, bool descending = false)
        {
            IndexFieldDefInfo fieldInfo = new IndexFieldDefInfo(lpszName, descending);

            m_IndexFields.Add(fieldInfo);
            m_nFields++;
        }

        internal string[] CreateFieldsNamesArray()
        {
            List<string> strNames = new List<string>();
            foreach (var field in m_IndexFields)
            {
                strNames.Add(field.m_strName);
	        }
            return strNames.ToArray();
        }

        public int FieldsCount()
        {
            return m_nFields;
        }
        internal string AddConstraintSQL(int dbPlatform)
        {
            string sqlCommand = "";

            string sqlFieldsList = CreateFieldsInfo();

            if (DBPlatform.IsMsJetType(dbPlatform))
            {
                sqlCommand = BaseAddConstraintSQL(sqlFieldsList);
            }
            else if (DBPlatform.IsMsSQLType(dbPlatform))
            {
                sqlCommand = BaseAddConstraintSQL(sqlFieldsList);
            }
            else if (DBPlatform.IsOracleType(dbPlatform))
            {
                sqlCommand = BaseAddConstraintSQL(sqlFieldsList);
            }
            else if (DBPlatform.IsSQLiteType(dbPlatform))
            {
                sqlCommand = BaseAddConstraintSQL(sqlFieldsList);
            }
            return sqlCommand;
        }

        internal string CreateFieldsInfo(int dbPlatform, bool addComma, bool addNewLine)
        {
            string strFieldName = "";
            return strFieldName;
        }
        public string CreateConstraintSQL(int dbPlatform, bool addComma, bool addNewLine)
        {
            string sqlCommand = "";

            string sqlFieldsList = CreateFieldsInfo();

            if (DBPlatform.IsMsJetType(dbPlatform))
            {
                sqlCommand = BaseCreateContraintSQL(sqlFieldsList);
            }
            else if (DBPlatform.IsMsSQLType(dbPlatform))
            {
                sqlCommand = BaseCreateContraintSQL(sqlFieldsList);
            }
            else if (DBPlatform.IsOracleType(dbPlatform))
            {
                sqlCommand = BaseCreateContraintSQL(sqlFieldsList);
            }
            else if (DBPlatform.IsSQLiteType(dbPlatform))
            {
                sqlCommand = BaseCreateContraintSQL(sqlFieldsList);
            }
            if (sqlCommand != "")
            {
                if (addComma)
                {
                    sqlCommand += ",";
                }
                if (addNewLine)
                {
                    sqlCommand += DBConstants.NEW_LINE_STR;
                }
            }
            return sqlCommand;
        }

        public string CreateIndexSQL(int dbPlatform)
        {
            string sqlCommand = "";

            string sqlFieldsList = CreateFieldsInfo();

            if (DBPlatform.IsMsJetType(dbPlatform))
            {
                sqlCommand = BaseCreateIndexSQL(sqlFieldsList);
            }
            else if (DBPlatform.IsMsSQLType(dbPlatform))
            {
                sqlCommand = BaseCreateIndexSQL(sqlFieldsList);
            }
            else if (DBPlatform.IsOracleType(dbPlatform))
            {
                sqlCommand = BaseCreateIndexSQL(sqlFieldsList);
            }
            else if (DBPlatform.IsSQLiteType(dbPlatform))
            {
                sqlCommand = BaseCreateIndexSQL(sqlFieldsList);
            }
            return sqlCommand;
        }

        private string CreateFieldsInfo()
        {
            string strNames = "";

            foreach (var field in m_IndexFields)
            {
                strNames += field.FieldInfo(m_bPrimary);
		        strNames += (",");
	        }
            return strNames.TrimEnd(DBConstants.TRIM_CHARS);
        }

        private string BaseAddConstraintSQL(string strNames)
        {
	        string strSQL = "";
	        if (m_bPrimary)
	        {
                strSQL = ("ALTER TABLE ");
                strSQL += m_strTable;
                strSQL += (" ADD CONSTRAINT ");
                strSQL += m_strName;
                strSQL += (" PRIMARY KEY (");
                strSQL += strNames;
                strSQL += (")");
            }
	        return strSQL;
        }

        private string BaseCreateContraintSQL(string strNames)
        {
	        string strSQL = "";
	        if (m_bPrimary)
	        {
                strSQL = ("CONSTRAINT ");
                strSQL += m_strName;
                strSQL += (" PRIMARY KEY (");
                strSQL += strNames;
		        strSQL += (")");
	        }
	        return strSQL;
        }

        private string BaseCreateIndexSQL(string strNames)
        {
	        string strSQL = "";
	        if (!m_bPrimary)
            {
                strSQL = ("CREATE INDEX ");
		        strSQL += m_strName;
		        strSQL += (" ON ");
		        strSQL += m_strTable;
		        strSQL += (" (");
                strSQL += strNames;
		        strSQL += (")");
	        }
	        return strSQL;
        }


        internal void Delete()
        {
            m_IndexFields.Clear();
        }


        public string InfoName()
        {
            return m_strTable + "::" + m_strName;
        }
    }
}
