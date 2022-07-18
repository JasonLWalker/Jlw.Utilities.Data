namespace Jlw.Utilities.Data.DbUtility
{
    /// <summary>
    /// Settings for a ModularDb repository
    /// </summary>
    public interface IModularDbOptions
    {
        /// <summary>
        /// Gets or sets the database client.
        /// </summary>
        /// <value>The database client.</value>
        IModularDbClient DbClient { get; set; }
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        string ConnectionString { get; set; }


    }
}