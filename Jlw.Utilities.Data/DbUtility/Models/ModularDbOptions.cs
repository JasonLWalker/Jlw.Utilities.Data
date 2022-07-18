namespace Jlw.Utilities.Data.DbUtility
{
    /// <inheritdoc/>
    public class ModularDbOptions : IModularDbOptions
    {
        /// <inheritdoc/>
        public IModularDbClient DbClient { get; set; }
        /// <inheritdoc/>
        public string ConnectionString { get; set; }

    }
}