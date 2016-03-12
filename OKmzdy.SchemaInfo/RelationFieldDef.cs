using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OKmzdy.SqlSchemaInfo
{
    class RelationFieldDef
    {
        public string m_strForeignName;
        public string m_strName;

        public RelationFieldDef(string lpszForeignName, string lpszName)
        {
            m_strForeignName = lpszForeignName;
            m_strName = lpszName; 
        }

        internal void ForeignName(string lpszName)
        {
            m_strForeignName = lpszName;
        }
    }
}
