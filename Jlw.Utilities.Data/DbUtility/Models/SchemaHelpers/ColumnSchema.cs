using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    public class ColumnSchema : IColumnSchema
    {
        public string Database { get; protected set; }
        public string Schema { get; protected set; }
        public string Table { get; protected set; }
        public string Name { get; protected set; }
        public int Order { get; protected set; }
        public string DataType { get; protected set; }
        public string DefaultValue { get; protected set; }
        public bool IsAutoNumber { get; protected set; }
        public bool IsNullable { get; protected set; }
        public int? MaxLength { get; protected set; }
        public int? NumericPrecision { get; protected set; }
        public int? NumericScale { get; protected set; }
        public string Collation { get; protected set; }
        public bool IsIdentity { get; protected set; }
        public ColumnSchema(
            string sDatabase = "", 
            string sSchema = "", 
            string sTable = "", 
            string sName = "", 
            int nOrder = 0,
            string sDataType = "", 
            string sDefaultValue = "", 
            bool bIsNullable = false, 
            int? nMaxLength = null, 
            int? nNumericPrecision = null,
            int? nNumericScale = null, 
            string sCollation = "", 
            bool bIsIdentity = false, 
            bool bIsAutoNumber = false)
        {
            Initialize(
                sDatabase, 
                sSchema, 
                sTable, 
                sName, 
                nOrder,
                sDataType, 
                sDefaultValue, 
                bIsNullable, 
                nMaxLength, 
                nNumericPrecision,
                nNumericScale, 
                sCollation, 
                bIsIdentity, 
                bIsAutoNumber
                );
        }

        public ColumnSchema(IDataRecord o)
        {
            Initialize(
                DataUtility.ParseString(o, "Database"),
                DataUtility.ParseString(o, "Schema"),
                DataUtility.ParseString(o, "Table"),
                DataUtility.ParseString(o, "Column"),
                DataUtility.ParseInt(o, "ColumnOrder"),
                DataUtility.ParseString(o, "DataType"),
                DataUtility.ParseString(o, "DefaultValue"),
                DataUtility.ParseBool(o, "IsNullable"),
                DataUtility.ParseNullableInt(o, "MaxLength"),
                DataUtility.ParseNullableInt(o, "NumericPrecision"),
                DataUtility.ParseNullableInt(o, "NumericScale"),
                DataUtility.ParseString(o, "Collation"),
                DataUtility.ParseBool(o["IsIdentity"])
            );
        }

        public ColumnSchema(IDictionary<string, object> o)
        {
            Initialize(
                DataUtility.ParseString(o, "Database"),
                DataUtility.ParseString(o, "Schema"),
                DataUtility.ParseString(o, "Table"),
                DataUtility.ParseString(o, "Column"),
                DataUtility.ParseInt(o, "ColumnOrder"),
                DataUtility.ParseString(o, "DataType"),
                DataUtility.ParseString(o, "DefaultValue"),
                DataUtility.ParseBool(o, "IsNullable"),
                DataUtility.ParseNullableInt(o, "MaxLength"),
                DataUtility.ParseNullableInt(o, "NumericPrecision"),
                DataUtility.ParseNullableInt(o, "NumericScale"),
                DataUtility.ParseString(o, "Collation"),
                DataUtility.ParseBool(o["IsIdentity"])
            );
        }


        protected void Initialize(
            string sDatabase = "", 
            string sSchema = "", 
            string sTable = "", 
            string sName = "", 
            int nOrder = 0,
            string sDataType = "", 
            string sDefaultValue = "", 
            bool bIsNullable = false, 
            int? nMaxLength = null, 
            int? nNumericPrecision = null,
            int? nNumericScale = null, 
            string sCollation = "", 
            bool bIsIdentity = false, 
            bool bIsAutoNumber = false
            )
        {
            Database = sDatabase;
            Schema = sSchema;
            Table = sTable;
            Name = sName;
            Order = nOrder;
            DataType = sDataType;
            DefaultValue = sDefaultValue;
            IsNullable = bIsNullable;
            MaxLength = nMaxLength;
            NumericPrecision = nNumericPrecision;
            NumericScale = nNumericScale;
            Collation = sCollation;
            IsIdentity = bIsIdentity;
            IsAutoNumber = bIsAutoNumber;

        }
    }

}