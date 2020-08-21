namespace Jlw.Utilities.Data.DbUtility
{
    public interface IDatabaseServerSchema
    {
        string Name { get; set; }
        string Type { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Description { get; set; }
        string ConnectionString { get; set; }
    }
}