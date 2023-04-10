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
    /// <inheritdoc />
    public class ModularDbClient<TConnection> : IModularDbClient where TConnection : IDbConnection, new()
    {
	    public int CommandTimeout { get; set; } = 30;
    
        public virtual DbConnectionStringBuilder GetConnectionBuilder(string connString = default) => new DbConnectionStringBuilder(){ConnectionString = connString ?? ""};

        public virtual IDbConnection GetConnection(string connString = default) => new TConnection() { ConnectionString = connString ?? ""};

        public IDbCommand GetCommand(string cmd, IDbConnection conn = default)
        {
            var oCmd = conn?.CreateCommand() ?? new TConnection().CreateCommand();
            oCmd.CommandTimeout = CommandTimeout;
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

        protected virtual IDbDataParameter GetNewParameterWithResolvedValue(object o, IDbDataParameter param)
        {
            if (o != null && (o.GetType().IsPrimitive || o is string))
            {
                var p = GetNewParameter(param);
                p.Value = o;
                return p;
            }

            Type t = o?.GetType() ?? typeof(object);
            if (o == null && param.SourceColumn == param.ParameterName)
            {
                throw new ArgumentNullException(nameof(o), "Object cannot be null when values are not provided in definition");
            }

            PropertyInfo[] properties = t?.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            if (properties.Any(x => x.CanRead && (x.Name.Equals(param.SourceColumn, StringComparison.InvariantCultureIgnoreCase) || (param.GetType() == typeof(DbCallbackParameter) && ((DbCallbackParameter)param).Callback != null))))
            {
                var prop = properties.FirstOrDefault(x => x.Name.Equals(param.SourceColumn, StringComparison.InvariantCultureIgnoreCase));


                var p = GetNewParameter(param);
                
                p.SourceColumn = default;
                if (param.GetType() == typeof(DbCallbackParameter) && ((DbCallbackParameter)param).Callback != null)
                    p.Value = ((DbCallbackParameter) param).Callback(o, param);
                else
                    p.Value = prop?.GetGetMethod(false) != null ? prop.GetValue(o) : DBNull.Value;

                return p;
            }

            return GetNewParameter(param);
        }

		public virtual int ExecuteNonQuery(IRepositoryMethodDefinition definition) => ExecuteNonQuery(null, default, definition);

		public virtual int ExecuteNonQuery(object o, string connString, IRepositoryMethodDefinition definition)
		{
			// Does definition exist?
			if (definition == null)
				throw new ArgumentNullException(nameof(definition), "No definition provided for repository method");

			// Does Query exist?
			if (string.IsNullOrWhiteSpace(definition.SqlQuery))
			{
				if (definition.CommandType == CommandType.StoredProcedure)
					throw new ArgumentException("Stored Procedure not provided in definition for ExecuteNonQuery", nameof(definition.SqlQuery));

				throw new ArgumentException("Sql Query not provided in definition for ExecuteNonQuery", nameof(definition.SqlQuery));
			}

			// Set return value
			int oReturn = default;


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

					oReturn = dbCmd.ExecuteNonQuery();
				}
				dbConn.Close();
			}
			return oReturn;
		}

        public virtual TReturn GetRecordObject<TReturn>(object o, string connString, IRepositoryMethodDefinition definition)
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

        public virtual TReturn GetRecordScalar<TReturn>(object o, string connString, IRepositoryMethodDefinition definition)
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

        public virtual IEnumerable<TReturn> GetRecordList<TReturn>(object o, string connString, IRepositoryMethodDefinition definition)
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
    }
}