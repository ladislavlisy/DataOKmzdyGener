using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.SqlSchemaInfo
{
    public class FieldDefInfo
    {
        const string NEW_LINE_STR = DBConstants.NEW_LINE_STR;
        const int DB_SINGLE = DBConstants.DB_SINGLE;
        const int DB_TEXT = DBConstants.DB_TEXT;
        const int DB_BOOLEAN = DBConstants.DB_BOOLEAN;
        const int DB_BYTE = DBConstants.DB_BYTE;
        const int DB_CURRENCY = DBConstants.DB_CURRENCY;
        const int DB_DATE = DBConstants.DB_DATE;
        const int DB_DATETIME = DBConstants.DB_DATETIME;
        const int DB_DOUBLE = DBConstants.DB_DOUBLE;
        const int DB_INTEGER = DBConstants.DB_INTEGER;
        const int DB_LONG = DBConstants.DB_LONG;
        const int DB_LONGBINARY = DBConstants.DB_LONGBINARY;
        const int DB_MEMO = DBConstants.DB_MEMO;
        const int DB_GUID = DBConstants.DB_GUID;

        static int dbFixedField = DBConstants.dbFixedField;
        static int dbUpdatableField = DBConstants.dbUpdatableField;

        public FieldDefInfo(UInt32 versFrom = 0, UInt32 versDrop = 9999)
        {
            m_strName = "";
            m_nType = 0;

            m_lCollatingOrder = 0;
            m_nOrdinalPosition = 0;
            m_strDefaultValue = "";
            m_strForeignName = "";
            m_strSourceField = "";
            m_strSourceTable = "";
            m_strValidationRule = "";
            m_strValidationText = "";
            m_lAttributes = dbFixedField | dbUpdatableField;
            m_lSize = 0;
            m_bRequired = false;
            m_bAllowZeroLength = false;
            m_VersFrom = versFrom;
            m_VersDrop = versDrop;
        }

        public string m_strName;
        public int m_nType;

        public int m_lCollatingOrder;
        public int m_nOrdinalPosition;
        public string m_strDefaultValue;
        public string m_strForeignName;
        public string m_strSourceField;
        public string m_strSourceTable;
        public string m_strValidationRule;
        public string m_strValidationText;
        public int m_lAttributes;
        public int m_lSize;
        public bool m_bRequired;
        public bool m_bAllowZeroLength;
        protected UInt32 m_VersFrom = 0;
        protected UInt32 m_VersDrop = 9999;

        public bool IsValidInVersion(UInt32 versCreate)
        {
            return (m_VersFrom <= versCreate && versCreate < m_VersDrop);
        }

        public string ColumnName()
        {
            return m_strName;
        }

        public string ParametrName()
        {
            return m_strName.Underscore().Camelize();
        }

        public string ReNameSQL(string lpszName, string lpszTable)
        {
            return DBConstants.EMPTY_STRING;
        }

        public void ReNameColumn(string newName)
        {
            m_strName = newName;
        }

        public string SetFieldSizeSQL(long size)
        {
            return DBConstants.EMPTY_STRING;
        }

        public string AlterRequiredSQL(bool bRequired)
        {
            return DBConstants.EMPTY_STRING;
        }

        public string AlterAllowZeroLengthSQL(bool bAllowZeroLength)
        {
            return DBConstants.EMPTY_STRING;
        }

        public bool IsAutoIncrement()
        {
            return DBPlatform.AutoIncrField(m_lAttributes);
        }

        public int DbColumnSize()
        {
            return DBPlatform.DataTypeSize(m_nType, m_lSize);
        }

        public bool DbColumnNull()
        {
            return !m_bRequired;
        }

        public bool IncludeColumnType()
        {
            bool bColumnTypeEx = true;
            switch (m_nType)
            {
                case DBConstants.DB_BOOLEAN:
                case DBConstants.DB_BYTE:
                case DBConstants.DB_INTEGER:
                case DBConstants.DB_LONG:
                case DBConstants.DB_TEXT:
                case DBConstants.DB_DATE:
                case DBConstants.DB_SINGLE:
                case DBConstants.DB_DOUBLE:
                    bColumnTypeEx = true;
                    break;
                case DBConstants.DB_CURRENCY:
                case DBConstants.DB_LONGBINARY:
                case DBConstants.DB_MEMO:
                case DBConstants.DB_GUID:
                    bColumnTypeEx = false;
                    break;
                default:
                    break;
            }
            return (bColumnTypeEx);
        }
    }
}
