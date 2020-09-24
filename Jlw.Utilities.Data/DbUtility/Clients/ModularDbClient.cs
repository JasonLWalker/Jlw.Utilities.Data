using System;
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
        public virtual DbConnectionStringBuilder GetConnectionBuilder() => new DbConnectionStringBuilder();
        public virtual DbConnectionStringBuilder GetConnectionBuilder(string connString) => new DbConnectionStringBuilder(){ConnectionString = connString};

        public virtual IDbConnection GetConnection() => new TConnection();

        public virtual IDbConnection GetConnection(string connString) => new TConnection() { ConnectionString = connString };

        public IDbCommand GetCommand(string cmd)
        {
            var conn = new TConnection();
            return GetCommand(cmd, conn);
        }
        
        public IDbCommand GetCommand(string cmd, IDbConnection conn)
        {
            var oCmd = conn.CreateCommand();
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

            return param;
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
            using var conn = new TConnection();
            using var cmd = conn.CreateCommand();
            return cmd.CreateParameter();
        }

        public virtual IDbDataParameter GetNewParameter(IDbDataParameter param)
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
                p.SourceVersion = param.SourceVersion;
                p.SourceColumn = param.SourceColumn;
                p.Value = param.Value;
            }

            return p;
        }
        #region GetRecordObject

        //public virtual TModel GetRecordObject<TModel>(string connString, RepositoryMethodDefinition<TModel, TModel> definition) => GetRecordObject<TModel, TModel>(default, connString, definition);
        public virtual TModel GetRecordObject<TModel>(TModel o, string connString, RepositoryMethodDefinition<TModel, TModel> definition) => GetRecordObject<TModel, TModel>(o, connString, definition);
        public virtual TModel GetRecordObject<TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false) => GetRecordObject<TModel, TModel>(connString, sSql, oParams, isStoredProc);

        public virtual TInterface GetRecordObject<TInterface, TModel>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface => this.GetRecordObject<TInterface, TModel, TModel>(o, connString, definition);
        /*
        {
            if (string.IsNullOrWhiteSpace(definition?.SqlQuery))
            {
                if (definition?.CommandType == CommandType.StoredProcedure)
                    throw new ArgumentException("Stored Procedure not provided in definition for GetRecordObject", nameof(definition.SqlQuery));

                throw new ArgumentException("Sql Query not provided in definition for GetRecordObject", nameof(definition.SqlQuery));
            }

            TInterface oReturn = default;

            using (var dbConn = GetConnection(connString))
            {
                dbConn.Open();
                using (var dbCmd = GetCommand(definition.SqlQuery, dbConn))
                {
                    PropertyInfo[] properties = typeof(TInterface).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    foreach (var param in definition.Parameters)
                    {
                        if (properties.Any(x => x.CanRead && x.Name == param.SourceColumn))
                        {
                            var prop = properties.FirstOrDefault(x => x.Name == param.SourceColumn);

                            var p = GetNewParameter(param);
                            p.SourceColumn = default;
                            if (o == null)
                            {
                                throw new ArgumentNullException(nameof(o), "Object cannot be null when values are not provided in definition");
                            }

                            p.Value = prop?.GetGetMethod(false) != null ? prop.GetValue(o) : DBNull.Value;
                            AddParameter(p, dbCmd);
                        }
                        else
                            AddParameter(param, dbCmd);
                    }

                    dbCmd.CommandType = definition.CommandType;

                    using (IDataReader sqlResult = dbCmd.ExecuteReader())
                    {
                        while (sqlResult.Read())
                        {
                            if (definition.Callback != null)
                            {
                                oReturn = (TInterface)definition.Callback(sqlResult);
                            }
                            else
                            {
                                oReturn = (TInterface)Activator.CreateInstance(typeof(TModel), new object[] { sqlResult });
                            }
                        }
                    }
                }
            }
            return oReturn;
        }
        */

        public virtual TInterface GetRecordObject<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false)
        {
            if (string.IsNullOrWhiteSpace(sSql))
            {
                if (isStoredProc)
                    throw new ArgumentException("Stored Procedure not provided for GetRecordObject", "sSql");

                throw new ArgumentException("Sql Query not provided for GetRecordObject", "sSql");

            }

            TInterface oReturn = default;

            using (var dbConn = GetConnection(connString))
            {
                dbConn.Open();
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
                            oReturn = (TInterface)Activator.CreateInstance(typeof(TModel), new object[] { sqlResult });
                        }
                    }
                }
            }
            return oReturn;
        }

        public virtual TReturn GetRecordObject<TInterface, TModel, TReturn>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface
        {
            if (string.IsNullOrWhiteSpace(definition?.SqlQuery))
            {
                if (definition?.CommandType == CommandType.StoredProcedure)
                    throw new ArgumentException("Stored Procedure not provided in definition for GetRecordObject", nameof(definition.SqlQuery));

                throw new ArgumentException("Sql Query not provided in definition for GetRecordObject", nameof(definition.SqlQuery));
            }

            TReturn oReturn = default;

            using (var dbConn = GetConnection(connString))
            {
                dbConn.Open();
                using (var dbCmd = GetCommand(definition.SqlQuery, dbConn))
                {
                    PropertyInfo[] properties = typeof(TInterface).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    foreach (var param in definition.Parameters)
                    {
                        if (properties.Any(x => x.CanRead && x.Name == param.SourceColumn))
                        {
                            var prop = properties.FirstOrDefault(x => x.Name == param.SourceColumn);

                            var p = GetNewParameter(param);
                            p.SourceColumn = default;
                            if (o == null)
                            {
                                throw new ArgumentNullException(nameof(o), "Object cannot be null when values are not provided in definition");
                            }

                            p.Value = prop?.GetGetMethod(false) != null ? prop.GetValue(o) : DBNull.Value;
                            AddParameter(p, dbCmd);
                        }
                        else
                            AddParameter(param, dbCmd);
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
            }
            return oReturn;
        }


        #endregion

        #region GetRecordList

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
                dbConn.Open();
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
        public override DbConnectionStringBuilder GetConnectionBuilder() => CreateConnectionBuilder();
        public override DbConnectionStringBuilder GetConnectionBuilder(string connString) => CreateConnectionBuilder(connString);


        // Retrieve strongly typed connection builder
        public virtual TConnBuilder CreateConnectionBuilder(string connString = "") => new TConnBuilder() { ConnectionString = connString };

        public virtual TConnection CreateConnection() => CreateConnection("");

        public virtual TConnection CreateConnection(string connString) => new TConnection() {ConnectionString = connString};

        public virtual TCommand CreateCommand(string cmd) => new TCommand { CommandText = cmd, Connection = new TConnection() };

        public virtual TCommand CreateCommand(string cmd, TConnection conn) => new TCommand {CommandText = cmd, Connection = conn};

        public virtual TParam AddParameter(TParam param, TCommand cmd)
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

            return param;
        }

        public virtual TParam CreateNewParameter() => new TParam();

        public virtual TParam CreateNewParameter(TParam param)
        {
            var p = new TParam();
            if (param != null)
            {
                p.DbType = param.DbType;
                p.Direction = param.Direction;
                p.ParameterName = param.ParameterName;
                p.Precision = param.Precision;
                p.Scale = param.Scale;
                p.Size = param.Size;
                p.SourceColumn = param.SourceColumn;
                p.Value = param.Value;
            }

            return p;
        }

        public virtual IDbDataParameter CreateNewParameter(IDbDataParameter param)
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

    }
}