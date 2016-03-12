using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.SqlSchemaInfo
{
    class IndexFieldDefInfo
    {
        public string m_strName;
        public bool m_bDescending;

        public IndexFieldDefInfo(string lpszName, bool descending = false)
        {
            m_strName = lpszName;
            m_bDescending = descending;
        }

        internal string FieldInfo(bool primary)
        {
            string strFieldInfo = m_strName;
            if (!primary)
            {
                if (m_bDescending)
                {
                    strFieldInfo += (" DESC");
                }
                else
                {
                    strFieldInfo += (" ASC");
                }
            }
            return strFieldInfo;
        }
    }
}
