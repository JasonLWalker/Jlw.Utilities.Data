using System;
using System.Data;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularDataRepositoryBase
    {
        protected string _connString = "";
        protected IModularDbClient _dbClient;

        public ModularDataRepositoryBase(IModularDbClient dbClient, string connString)
        {
            _connString = connString;
            _dbClient = dbClient;
        }

        #region Internal Members
        protected virtual IDbConnection GetConnection(string connString)
        {
            if (string.IsNullOrWhiteSpace(connString))
            {
                throw new ArgumentException("Invalid Connection String. Connection string may not be empty or null.");
            }

            IDbConnection dbConn = _dbClient?.GetConnection(connString);

            if (dbConn == null)
            {
                throw new InvalidOperationException("Unable to retrieve a valid database connection.");
            }

            return dbConn;
        }
        protected virtual IDbCommand GetCommand(string sqlString, IDbConnection dbConn)
        {
            if (string.IsNullOrWhiteSpace(sqlString))
            {
                throw new ArgumentException("Invalid command string. SQL command may not be empty or null.");
            }

            IDbCommand dbCmd = _dbClient?.GetCommand(sqlString, dbConn);

            if (dbCmd == null)
            {
                throw new InvalidOperationException("Unable to initialize database command.");
            }

            return dbCmd;
        }
        #endregion
        
    }
}
