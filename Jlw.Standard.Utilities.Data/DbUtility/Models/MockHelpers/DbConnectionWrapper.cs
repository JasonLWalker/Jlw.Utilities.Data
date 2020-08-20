using System.Data;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class DbConnectionWrapper<TModel> : IDbConnection
        where TModel : class, IDbConnection, new()
    {
        protected TModel _dbConn = new TModel();

        public virtual void Dispose() => _dbConn.Dispose();

        public virtual IDbTransaction BeginTransaction() => _dbConn.BeginTransaction();

        public virtual IDbTransaction BeginTransaction(IsolationLevel il) => _dbConn.BeginTransaction(il);

        public virtual void ChangeDatabase(string databaseName) => _dbConn.ChangeDatabase(databaseName);

        public virtual void Close() => _dbConn.Close();

        public virtual IDbCommand CreateCommand() => _dbConn.CreateCommand();

        public virtual void Open() => _dbConn.Open();

        public string ConnectionString
        {
            get => _dbConn.ConnectionString;
            set => _dbConn.ConnectionString = value;
        }

        public int ConnectionTimeout => _dbConn.ConnectionTimeout;
        public string Database => _dbConn.Database;
        public ConnectionState State => _dbConn.State;
    }
}