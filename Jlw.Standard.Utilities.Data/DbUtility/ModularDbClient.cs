using System.Data;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class ModularDbClient<TConnection, TCommand, TParam> : IModularDbClient         
        where TConnection : IDbConnection, new()
        where TCommand : IDbCommand, new()
        where TParam : IDbDataParameter, new()

    {
        public virtual IDbConnection GetConnection(string connString)
        {
            return new TConnection() {ConnectionString = connString};
        }

        public virtual IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn)
        {
            return new TCommand {CommandText = cmd, Connection = conn};
        }

        public virtual IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd)
        {
            var param = cmd.CreateParameter();
            param.Value = value;
            param.ParameterName = paramName;
            cmd.Parameters.Add(param);
            return param;
        }

        public virtual IDbDataParameter GetNewParameter()
        {
            return new TParam();
        }
    }
}