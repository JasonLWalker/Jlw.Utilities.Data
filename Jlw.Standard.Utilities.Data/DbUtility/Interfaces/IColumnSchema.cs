namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public interface IColumnSchema
    {
        string Database { get; }
        string Schema { get; }
        string Table { get; }
        string Name { get; }
        int Order { get; }
        string DataType { get; }
        string DefaultValue { get; }
        bool IsNullable { get; }
        int? MaxLength { get; }
        int? NumericPrecision { get; }
        int? NumericScale { get; }
        string Collation { get; }
        bool IsIdentity { get; }
        bool IsAutoNumber { get; }
    }
}