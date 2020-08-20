using System.Data;
using System.Data.Common;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class DbConnectionWrapper<TModel> : DbConnection
        where TModel : DbConnection, new()
    {
        protected internal TModel DbConn = new TModel();

        public new void Dispose() => DbConn.Dispose();

        public static implicit operator TModel(DbConnectionWrapper<TModel> o) => o.DbConn;

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return DbConn.BeginTransaction(isolationLevel);
        }

        public new IDbTransaction BeginTransaction() => DbConn.BeginTransaction();

        public new IDbTransaction BeginTransaction(IsolationLevel il) => DbConn.BeginTransaction(il);

        public override void ChangeDatabase(string databaseName) => DbConn.ChangeDatabase(databaseName);

        public override void Close() => DbConn.Close();

        public new IDbCommand CreateCommand() => DbConn.CreateCommand();
        protected override DbCommand CreateDbCommand()
        {
            return DbConn.CreateCommand();
        }

        public override void Open() => DbConn.Open();

        public override string ConnectionString
        {
            get => DbConn.ConnectionString;
            set => DbConn.ConnectionString = value;
        }

        public override int ConnectionTimeout => DbConn.ConnectionTimeout;
        public override string Database => DbConn.Database;
        public override string DataSource => DbConn.DataSource;
        public override string ServerVersion => DbConn.ServerVersion;
        public override ConnectionState State => DbConn.State;
    }
}