using System;
using System.Collections.Generic;
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