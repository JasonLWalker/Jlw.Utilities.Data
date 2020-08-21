﻿using System.Data;
using MySql.Data.MySqlClient;

namespace Jlw.Utilities.Data.DbUtility
{
    public class NullDbConnection : NullDbConnection<NullDbCommand>
    {

    }

    public class NullDbConnection<TCommand> : IDbConnection
        where TCommand : IDbCommand, new()
    {
        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }

        public IDbTransaction BeginTransaction()
        {
            throw new System.NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }

        public IDbCommand CreateCommand()
        {
            return new TCommand();
        }

        public void Open()
        {
            throw new System.NotImplementedException();
        }

        public string ConnectionString { get; set; }
        public int ConnectionTimeout { get; }
        public string Database { get; }
        public ConnectionState State { get; }
    }
}
