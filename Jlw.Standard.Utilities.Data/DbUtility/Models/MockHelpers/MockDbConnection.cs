using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;


namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class MockDbConnection : IDbConnection
    {
        protected readonly Dictionary<string, List<Dictionary<string, object>>> _dbData = new Dictionary<string, List<Dictionary<string, object>>>();
        public string ConnectionString { get; set; } = "";
        public int ConnectionTimeout { get; } = 15;
        public string Database { get; protected set; } = "";
        public ConnectionState State { get; protected set; } = ConnectionState.Closed;


        public void Dispose()
        {
            State = ConnectionState.Closed;
            _dbData.Clear();
        }

        public IDbTransaction BeginTransaction()
        {
            return new NullDbTransaction(this, IsolationLevel.Unspecified);
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return new NullDbTransaction(this, il);
        }

        public void ChangeDatabase(string databaseName)
        {
            switch (State)
            {
                case ConnectionState.Open:
                    if (_dbData.ContainsKey(databaseName))
                    {
                        Database = databaseName;
                        return;
                    }
                    break;
            }
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            switch (State)
            {
                case ConnectionState.Open:
                    State = ConnectionState.Closed;
                    break;
                default:
                    throw new System.NotImplementedException();
            }
        }

        public IDbCommand CreateCommand()
        {
            throw new System.NotImplementedException();
        }

        public void Open()
        {
            switch (State)
            {
                case ConnectionState.Closed:
                    State = ConnectionState.Open;
                    break;
                default:
                    throw new System.NotImplementedException();
            }
        }

    }
}