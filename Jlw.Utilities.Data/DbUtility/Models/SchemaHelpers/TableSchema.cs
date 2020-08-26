using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    public class TableSchema : ITableSchema
    {
        public string Database { get; protected set; }
        public string Schema { get; protected set; }
        public string Name { get; protected set; }
        public string Type { get; protected set; }

        public TableSchema()
        {
            Database = "";
            Schema = "";
            Name = "";
            Type = "";
        }

        public TableSchema(IDataRecord o)
        {
            Database = (o["Database"] ?? "").ToString();
            Schema = (o["Schema"] ?? "").ToString();
            Name = (o["Name"] ?? "").ToString();
            Type = (o["Type"] ?? "").ToString();
        }


    }
}