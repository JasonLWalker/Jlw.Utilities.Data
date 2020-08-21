using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;


namespace Jlw.Utilities.Data.DbUtility
{

    public class MockDbConnection : MockDbConnection<NullDbCommand>
    {

    }


    public class MockDbConnection<TCommand> : IDbConnection
        where TCommand : IDbCommand, new()
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
                    throw new ArgumentException("The database name is not valid.");
            }
            throw new InvalidOperationException("The connection is not open.");
        }

        public void Close()
        {
            switch (State)
            {
                case ConnectionState.Open:
                    State = ConnectionState.Closed;
                    break;
            }
            throw new System.NotImplementedException();
        }

        public IDbCommand CreateCommand()
        {
            return new TCommand();
        }

        public void Open()
        {
            switch (State)
            {
                case ConnectionState.Closed:
                    State = ConnectionState.Open;
                    break;
            }
            throw new System.NotImplementedException();
        }

    }
}