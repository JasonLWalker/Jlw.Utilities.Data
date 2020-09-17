using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace Jlw.Utilities.Data.DbUtility
{
    public class ModularDbClient<TConnection, TCommand, TParam> : ModularDbClient<TConnection, TCommand, TParam, DbConnectionStringBuilder>
        where TConnection : IDbConnection, new()
        where TCommand : IDbCommand, new()
        where TParam : IDbDataParameter, new()
    { }

    public class ModularDbClient<TConnection, TCommand, TParam, TConnBuilder> : IModularDbClient         
        where TConnection : IDbConnection, new()
        where TCommand : IDbCommand, new()
        where TParam : IDbDataParameter, new()
        where TConnBuilder : DbConnectionStringBuilder, new()

    {

        //public DbConnectionStringBuilder ConnectionBuilder => new TConnBuilder();
        public virtual DbConnectionStringBuilder CreateConnectionBuilder(string connString = "")
        {
            return new TConnBuilder() { ConnectionString = connString };
        }

        public virtual IDbConnection CreateConnection(string connString) 
        {
            return new TConnection() {ConnectionString = connString};
        }

        public virtual IDbConnection GetConnection(string connString) => CreateConnection(connString);

        public virtual IDbCommand CreateCommand(string cmd, System.Data.IDbConnection conn)
        {
            return new TCommand {CommandText = cmd, Connection = conn};
        }
        public virtual IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn) => CreateCommand(cmd, conn);

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

        public virtual IDbDataParameter CreateNewParameter()
        {
            return new TParam();
        }

        public virtual IDbDataParameter CreateNewParameter(IDbDataParameter param)
        {
            var p = new TParam();
            if (param != null)
            {
                p.DbType = param.DbType;
                p.Direction = param.Direction;
                p.ParameterName= param.ParameterName;
                p.Precision = param.Precision;
                p.Scale = param.Scale;
                p.Size = param.Size;
                p.SourceColumn = param.SourceColumn;
                //p.SourceVersion = param.SourceVersion;
                p.Value = param.Value;
            }

            return p;
        }

        public virtual IDbDataParameter GetNewParameter() => CreateNewParameter();

        public virtual TInterface GetRecordObject<TInterface, TModel>(TInterface o, string connString, RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface
        {
            if (string.IsNullOrWhiteSpace(definition?.SqlQuery))
            {
                if (definition?.CommandType == CommandType.StoredProcedure)
                    throw new NotImplementedException("Stored Procedure not provided for GetRecord");

                throw new NotImplementedException("Sql Query not provided for GetRecord");
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

                            var p = CreateNewParameter();
                            p.DbType = param.DbType;
                            p.Direction = param.Direction;
                            p.ParameterName = param.ParameterName;
                            p.Precision = param.Precision;
                            p.Scale = param.Scale;
                            p.Size = param.Size;
                            //p.SourceVersion = param.SourceVersion;
                            p.Value = prop?.GetGetMethod(false) != null ? prop.GetValue(o) : param.Value;
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

        public virtual IEnumerable<TInterface> GetRecordList<TInterface, TModel>(RepositoryMethodDefinition<TInterface, TModel> definition) where TModel : TInterface
        {
            throw new NotImplementedException();
        }



        public virtual TInterface GetRecordObject<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false)
        {
            if (string.IsNullOrWhiteSpace(sSql))
            {
                if (isStoredProc)
                    throw new NotImplementedException("Stored Procedure not provided for GetRecord");

                throw new NotImplementedException("Sql Query not provided for GetRecord");

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
                            oReturn = (TInterface)Activator.CreateInstance(typeof(TModel), new object[]{sqlResult}); 
                        } 
                    } 
                } 
            }
            return oReturn;
        }

        public virtual IEnumerable<TInterface> GetRecordList<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false)
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
                            oReturn.Add((TInterface)Activator.CreateInstance(typeof(TModel), new object[]{sqlResult})); 
                        } 
                    } 
                } 
            }
            return oReturn;
        }
    }
}