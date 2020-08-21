namespace Jlw.Utilities.Data.DbUtility
{
    public class DatabaseServerSchema : IDatabaseServerSchema
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string ConnectionString { get; set; }

    }
}