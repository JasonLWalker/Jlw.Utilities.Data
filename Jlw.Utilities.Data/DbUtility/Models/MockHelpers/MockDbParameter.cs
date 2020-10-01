using System;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    public class MockDbParameter : IDbDataParameter
    {
        protected static bool CheckNullable<T>(T obj)
        {
            return default(T) == null && typeof(T).BaseType != null && "ValueType".Equals(typeof(T).BaseType.Name);
        }

        public DbType DbType { get; set; }
        public ParameterDirection Direction { get; set; }

        public bool IsNullable => CheckNullable(Value.GetType());

        public string ParameterName { get; set; }
        public string SourceColumn { get; set; }
        public DataRowVersion SourceVersion { get; set; } = DataRowVersion.Default;
        public object Value { get; set; }
        public byte Precision { get; set; }
        public byte Scale { get; set; }
        public int Size { get; set; }
    }
}