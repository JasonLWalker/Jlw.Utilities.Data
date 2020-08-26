using System;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    public class DatabaseSchema : IDatabaseSchema
    {
        public string Name { get; protected set; }
        public string DefaultCollation { get; protected set; }
        public DateTime CreationDate { get; protected set; }

        public DatabaseSchema()
        {
            Name = "";
            DefaultCollation = "";
            CreationDate = DateTime.MinValue;
        }

        public DatabaseSchema(IDataRecord o)
        {
            Name = (o["Name"] ?? "").ToString();
            DefaultCollation = (o["CollationName"] ?? "").ToString();
            CreationDate = DataUtility.ParseNullableDateTime(o["CreationDate"] ?? "") ?? DateTime.MinValue;
        }

    }
}