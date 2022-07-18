namespace Jlw.Utilities.Data.DbUtility
{
    /// <summary>
    /// Interface ITableSchema
    /// </summary>
    /// TODO Edit XML Comment Template for ITableSchema
    public interface ITableSchema
    {
        string Database { get; }
        string Schema { get;  }
        string Name { get; }
        string Type { get; }
    }
}