using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace Jlw.Utilities.Data.DbUtility
{
    public class ModularDbClient<TConnection> : IModularDbClient
        where TConnection : IDbConnection, new()
    {
        public virtual DbConnectionStringBuilder GetConnectionBuilder(string connString = default) => new DbConnectionStringBuilder(){ConnectionString = connString ?? ""};

        public virtual IDbConnection GetConnection(string connString = default) => new TConnection() { ConnectionString = connString ?? ""};

        public IDbCommand GetCommand(string cmd, IDbConnection conn = default)
        {
            var oCmd = conn?.CreateCommand() ?? new TConnection().CreateCommand();
            oCmd.CommandText = cmd;
            return oCmd;
        }

        public virtual IDbDataParameter AddParameter(IDbDataParameter param, System.Data.IDbCommand cmd)
        {
            var p = cmd.CreateParameter();
            if (param != null)
            {
                p.DbType = param.DbType;
                p.Direction = param.Direction;
                p.ParameterName = param.ParameterName;
                p.Precision = param.Precision;
                p.Scale = param.Scale;
                p.Size = param.Size;
                p.SourceColumn = param.SourceColumn;
                //p.SourceVersion = param.SourceVersion;
                p.Value = param.Value;
            }

            cmd.Parameters.Add(p);

            return p;
        }

        public virtual IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd)
        {
            var param = cmd.CreateParameter();
            param.Value = value;
            param.ParameterName = paramName;
            cmd.Parameters.Add(param);
            return param;
        }

        public virtual IDbDataParameter GetNewParameter(IDbDataParameter param = null, IDbCommand cmd = null)
        {
            IDbDataParameter p;
            if (cmd != null)
            {
                p = cmd.CreateParameter();
                if (param == null)
                    return p;
            }
            else
            {
                using var conn = new TConnection();
                using var newCmd = conn.CreateCommand();
                p = newCmd.CreateParameter();
            }

            if (param == null)
                return p;

            p.DbType = param.DbType;
            try { p.Direction = param.Direction; } catch { /* Not all clients support Direction, so catch exceptions */ }
            p.ParameterName = param.ParameterName;
            p.Precision = param.Precision;
            p.Scale = param.Scale;
            p.Size = param.Size;
            try { p.SourceVersion = param.SourceVersion; } catch { /* Catch invalid source versions */ }
            p.SourceColumn = param.SourceColumn;
            p.Value = param.Value;

            return p;
        }
        
        protected virtual void OpenConnection(IDbConnection dbConn)
        {
            // Open the connection. Add any additional manipulation needed by overriding this method
            dbConn.Open();
        }

        protected virtual IDbDataParameter GetNewParameterWithResolvedValue<TModel>(TModel o, IDbDataParameter param) 
        {
            PropertyInfo[] properties = typeof(TModel).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (properties.Any(x => x.CanRead && (x.Name.Equals(param.SourceColumn, StringComparison.InvariantCultureIgnoreCase) || (param.GetType() == typeof(DbCallbackParameter) && ((DbCallbackParameter)param).Callback != null))))
            {
                var prop = properties.FirstOrDefault(x => x.Name.Equals(param.SourceColumn, StringComparison.InvariantCultureIgnoreCase));


                var p = GetNewParameter(param);
                
                p.SourceColumn = default;
                if (o == null)
                {
                    throw new ArgumentNullException(nameof(o),
                        "Object cannot be null when values are not provided in definition");
                }

                if (param.GetType() == typeof(DbCallbackParameter) && ((DbCallbackParameter)param).Callback != null)
                    p.Value = ((DbCallbackParameter) param).Callback(o, param);
                else
                    p.Value = prop?.GetGetMethod(false) != null ? prop.GetValue(o) : DBNull.Value;

                return p;
            }

            return GetNewParameter(param);
        }

        //public virtual RepositoryMethodDefinition<TInterface, TModel> BuildRepositoryMethodDefinition<TInterface, TModel>(string sSql, IEnumerable<KeyValuePair<string, object>> aParams = null, bool isStoredProc = false) where TModel : TInterface => new RepositoryMethodDefinition<TInterface, TModel>(sSql, isStoredProc ? CommandType.StoredProcedure : CommandType.Text, aParams);

        //public virtual RepositoryMethodDefinition<TInterface, TModel> BuildRepositoryMethodDefinition<TInterface, TModel>(string sSql, IEnumerable<string> aParams = null, bool isStoredProc = false) where TModel : TInterface => new RepositoryMethodDefinition<TInterface, TModel>(sSql, isStoredProc ? CommandType.StoredProcedure : CommandType.Text, aParams);

        #region GetRecordObject
        /*
        public virtual object GetRecordObject(object o, string connString, RepositoryMethodDefinition<object, object> definition) => GetRecordObject<object, object, object>(o, connString, definition);
        public virtual TModel GetRecordObject<TModel>(TModel o, string connString, RepositoryMethodDefinition<TModel, TModel> definition) => GetRecordObject<TModel, TModel, TModel>(o, connString, definition);
        public virtual TInterface GetRecordObject<TInterface, TModel>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface => GetRecordObject<TInterface, TModel, TModel>(o, connString, definition);
        */

        public virtual TReturn GetRecordObject<TInterface, TModel, TReturn>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface
        {
            // Does definition exist?
            if (definition == null)
                throw new ArgumentNullException(nameof(definition), "No definition provided for repository method");
            
            // Does Query exist?
            if (string.IsNullOrWhiteSpace(definition.SqlQuery))
            {
                if (definition.CommandType == CommandType.StoredProcedure)
                    throw new ArgumentException("Stored Procedure not provided in definition for GetRecordObject", nameof(definition.SqlQuery));

                throw new ArgumentException("Sql Query not provided in definition for GetRecordObject", nameof(definition.SqlQuery));
            }

            // Set return value
            TReturn oReturn = default;


            using (var dbConn = GetConnection(connString))
            {
                OpenConnection(dbConn);
                using (var dbCmd = GetCommand(definition.SqlQuery, dbConn))
                {
                    foreach (var param in definition.Parameters)
                    {
                        AddParameter(GetNewParameterWithResolvedValue(o, param), dbCmd);
                    }

                    dbCmd.CommandType = definition.CommandType;

                    using (IDataReader sqlResult = dbCmd.ExecuteReader())
                    {
                        while (sqlResult.Read())
                        {
                            if (definition.Callback != null)
                            {
                                oReturn = (TReturn)definition.Callback(sqlResult);
                            }
                            else
                            {
                                oReturn = (TReturn)Activator.CreateInstance(typeof(TReturn), new object[] { sqlResult });
                            }
                        }
                    }
                }
                dbConn.Close();
            }
            return oReturn;
        }

        /*
        public virtual object GetRecordObject(object o, string connString, string sSql, IEnumerable<string> oParams = null, bool isStoredProc = false) => GetRecordObject<object, object, object>(o, connString, BuildRepositoryMethodDefinition<object, object>(sSql, oParams, isStoredProc));
        public virtual TModel GetRecordObject<TModel>(TModel o, string connString, string sSql, IEnumerable<string> oParams = null, bool isStoredProc = false) => GetRecordObject<TModel, TModel, TModel>(o, connString, BuildRepositoryMethodDefinition<TModel, TModel>(sSql, oParams, isStoredProc));
        public virtual TInterface GetRecordObject<TInterface, TModel>(TInterface o, string connString, string sSql, IEnumerable<string> oParams = null, bool isStoredProc = false) where TModel : TInterface => GetRecordObject<TInterface, TModel, TModel>(o, connString, BuildRepositoryMethodDefinition<TInterface, TModel>(sSql, oParams, isStoredProc));
        public virtual TReturn GetRecordObject<TInterface, TModel, TReturn>(TInterface o, string connString, string sSql, IEnumerable<string> oParams = null, bool isStoredProc = false) where TModel : TInterface => GetRecordObject<TInterface, TModel, TReturn>(o, connString, BuildRepositoryMethodDefinition<TInterface, TModel>(sSql, oParams, isStoredProc));


        public virtual object GetRecordObject(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) => GetRecordObject<object, object, object>(default, connString, BuildRepositoryMethodDefinition<object, object>(sSql, oParams, isStoredProc));
        public virtual TModel GetRecordObject<TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) => GetRecordObject<TModel, TModel, TModel>(default, connString, BuildRepositoryMethodDefinition<TModel, TModel>(sSql, oParams, isStoredProc));
        public virtual TInterface GetRecordObject<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) where TModel : TInterface => GetRecordObject<TInterface, TModel, TModel>(default, connString, BuildRepositoryMethodDefinition<TInterface, TModel>(sSql, oParams, isStoredProc));
        public virtual TReturn GetRecordObject<TInterface, TModel, TReturn>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) where TModel : TInterface => GetRecordObject<TInterface, TModel, TReturn>(default, connString, BuildRepositoryMethodDefinition<TInterface, TModel>(sSql, oParams, isStoredProc));


        public virtual object GetRecordObject(object o, string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) => GetRecordObject<object, object, object>(o, connString, BuildRepositoryMethodDefinition<object, object>(sSql, oParams, isStoredProc));
        public virtual TModel GetRecordObject<TModel>(TModel o, string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) => GetRecordObject<TModel, TModel, TModel>(o, connString, BuildRepositoryMethodDefinition<TModel, TModel>(sSql, oParams, isStoredProc));
        public virtual TInterface GetRecordObject<TInterface, TModel>(TInterface o, string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) where TModel : TInterface => GetRecordObject<TInterface, TModel, TModel>(o, connString, BuildRepositoryMethodDefinition<TInterface, TModel>(sSql, oParams, isStoredProc));
        public virtual TReturn GetRecordObject<TInterface, TModel, TReturn>(TInterface o, string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) where TModel : TInterface => GetRecordObject<TInterface, TModel, TReturn>(o, connString, BuildRepositoryMethodDefinition<TInterface, TModel>(sSql, oParams, isStoredProc));
        */

        #endregion
        /*
        public virtual object GetRecordScalar(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) => GetRecordScalar<object, object, object>(default, connString, BuildRepositoryMethodDefinition<object, object>(sSql, oParams, isStoredProc));
        */

        public virtual TReturn GetRecordScalar<TInterface, TModel, TReturn>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface
        {
            // Does definition exist?
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition), "No definition provided for repository method");
            }

            // Does Query exist?
            if (string.IsNullOrWhiteSpace(definition.SqlQuery))
            {
                if (definition.CommandType == CommandType.StoredProcedure)
                    throw new ArgumentException("Stored Procedure not provided in definition for GetRecordScalar", nameof(definition.SqlQuery));

                throw new ArgumentException("Sql Query not provided in definition for GetRecordScalar", nameof(definition.SqlQuery));
            }

            // Set return value
            TReturn oReturn = default;

            using (var dbConn = GetConnection(connString))
            {
                OpenConnection(dbConn);
                using (var dbCmd = GetCommand(definition.SqlQuery, dbConn))
                {
                    foreach (var param in definition.Parameters)
                    {
                        AddParameter(GetNewParameterWithResolvedValue(o, param), dbCmd);
                    }

                    dbCmd.CommandType = definition.CommandType;

                    object result = dbCmd.ExecuteScalar();
                    if (definition.Callback != null)
                    {
                        oReturn = (TReturn)definition.Callback(result);
                    }
                    else
                    {
                        oReturn = DataUtility.Parse<TReturn>(result);
                    }
                }
                dbConn.Close();
            }
            return oReturn;
        }


        #region GetRecordList
        /*
        public virtual IEnumerable<TModel> GetRecordList<TModel>(string connString, RepositoryMethodDefinition<TModel, TModel> definition) => GetRecordList<TModel, TModel>(default, definition);
        public virtual IEnumerable<TModel> GetRecordList<TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) => GetRecordList<TModel, TModel>(default, connString, sSql, oParams, isStoredProc);
        public virtual IEnumerable<TModel> GetRecordList<TModel>(TModel o, string connString, RepositoryMethodDefinition<TModel, TModel> definition) => GetRecordList<TModel, TModel>(o, connString, definition);
        public virtual IEnumerable<TModel> GetRecordList<TModel>(TModel o, string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) => GetRecordList<TModel, TModel>(o, connString, sSql, oParams, isStoredProc);


        public virtual IEnumerable<TInterface> GetRecordList<TInterface, TModel>(string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface => GetRecordList<TInterface, TModel>(default, connString, definition);

        public virtual IEnumerable<TInterface> GetRecordList<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) => GetRecordList<TInterface, TModel>(default, connString, sSql, oParams, isStoredProc);

        public virtual IEnumerable<TInterface> GetRecordList<TInterface, TModel>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface
        {
            throw new NotImplementedException();
        }
        public virtual IEnumerable<TInterface> GetRecordList<TInterface, TModel>(TInterface o, string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false)
        {
            if (string.IsNullOrWhiteSpace(sSql))
            {
                if (isStoredProc)
                    throw new NotImplementedException("Stored Procedure not provided for GetRecord");

                throw new NotImplementedException("Sql Query not provided for GetRecord");

            }

            List<TInterface> oReturn = new List<TInterface>();

            using (var dbConn = GetConnection(connString))
            {
                //dbConn.Open();
                OpenConnection(dbConn);

                using (var dbCmd = GetCommand(sSql, dbConn))
                {
                    foreach (var kvp in oParams ?? new KeyValuePair<string, object>[] { })
                    {
                        AddParameterWithValue(kvp.Key, kvp.Value, dbCmd);
                    }

                    if (isStoredProc)
                        dbCmd.CommandType = CommandType.StoredProcedure;

                    using (IDataReader sqlResult = dbCmd.ExecuteReader())
                    {
                        while (sqlResult.Read())
                        {
                            oReturn.Add((TInterface)Activator.CreateInstance(typeof(TModel), new object[] { sqlResult }));
                        }
                    }
                }
            }
            return oReturn;
        }
        */

        public virtual IEnumerable<TReturn> GetRecordList<TInterface, TModel, TReturn>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface 
        {
            // Does definition exist?
            if (definition == null)
                throw new ArgumentNullException(nameof(definition), "No definition provided for repository method");

            // Does Query exist?
            if (string.IsNullOrWhiteSpace(definition.SqlQuery))
            {
                if (definition.CommandType == CommandType.StoredProcedure)
                    throw new ArgumentException("Stored Procedure not provided in definition for GetRecordObject", nameof(definition.SqlQuery));

                throw new ArgumentException("Sql Query not provided in definition for GetRecordObject", nameof(definition.SqlQuery));
            }

            // Set return value
            List<TReturn> oReturn = new List<TReturn>();


            using (var dbConn = GetConnection(connString))
            {
                OpenConnection(dbConn);
                using (var dbCmd = GetCommand(definition.SqlQuery, dbConn))
                {
                    foreach (var param in definition.Parameters)
                    {
                        AddParameter(GetNewParameterWithResolvedValue(o, param), dbCmd);
                    }

                    dbCmd.CommandType = definition.CommandType;

                    using (IDataReader sqlResult = dbCmd.ExecuteReader())
                    {
                        while (sqlResult.Read())
                        {
                            if (definition.Callback != null)
                            {
                                oReturn.Add((TReturn)definition.Callback(sqlResult));
                            }
                            else
                            {
                                oReturn.Add((TReturn)Activator.CreateInstance(typeof(TReturn), new object[] { sqlResult }));
                            }
                        }
                    }
                }
                dbConn.Close();
            }
            return oReturn;
        }

        #endregion

    }

    // Class creation with base connection string builder
    public class ModularDbClient<TConnection, TCommand, TParam> : ModularDbClient<TConnection, TCommand, TParam, DbConnectionStringBuilder>
        where TConnection : IDbConnection, new()
        where TCommand : IDbCommand, new()
        where TParam : IDbDataParameter, new()
    { }

    // Strongly typed class creation
    public class ModularDbClient<TConnection, TCommand, TParam, TConnBuilder> : ModularDbClient<TConnection>, IModularDbClient<TConnection, TCommand, TParam, TConnBuilder>
        where TConnection : IDbConnection, new()
        where TCommand : IDbCommand, new()
        where TParam : IDbDataParameter, new()
        where TConnBuilder : DbConnectionStringBuilder, new()
    {
        // Retrieve weakly typed connection builder
        //public override DbConnectionStringBuilder GetConnectionBuilder() => CreateConnectionBuilder();
        public override DbConnectionStringBuilder GetConnectionBuilder(string connString = default) => CreateConnectionBuilder(connString);


        // Retrieve strongly typed connection builder
        public virtual TConnBuilder CreateConnectionBuilder(string connString = "") => new TConnBuilder() { ConnectionString = connString };

        public virtual TConnection CreateConnection() => CreateConnection("");

        public virtual TConnection CreateConnection(string connString) => new TConnection() {ConnectionString = connString};

        public virtual TCommand CreateCommand(string cmd) => new TCommand { CommandText = cmd, Connection = new TConnection() };

        public virtual TCommand CreateCommand(string cmd, TConnection conn) => new TCommand {CommandText = cmd, Connection = conn};

        public virtual TParam AddParameter(TParam param, TCommand cmd) => (TParam)base.AddParameter(param, cmd);

        public virtual TParam CreateNewParameter(TParam param = default, TCommand cmd=default) => AddParameter(param, cmd ?? new TCommand());

        public virtual IDbDataParameter CreateNewParameter(IDbDataParameter param, IDbCommand cmd = null) => GetNewParameter(param, cmd ?? new TCommand());
        /*
        {

            var p = GetNewParameter();
            if (param != null)
            {
                p.DbType = param.DbType;
                try { p.Direction = param.Direction; } catch {}
                p.ParameterName = param.ParameterName;
                p.Precision = param.Precision;
                p.Scale = param.Scale;
                p.Size = param.Size;
                p.SourceColumn = param.SourceColumn;
                p.Value = param.Value;
            }

            return p;
        }
        */
    }
}