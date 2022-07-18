namespace Jlw.Utilities.Data.DbUtility
{
    /// <summary>
    /// Interface IDatabaseServerSchema
    /// </summary>
    /// TODO Edit XML Comment Template for IDatabaseServerSchema
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