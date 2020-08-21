namespace Jlw.Utilities.Data.DbUtility
{
    public interface ITableSchema
    {
        string Database { get; }
        string Schema { get;  }
        string Name { get; }
        string Type { get; }
    }
}