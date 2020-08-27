using System;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    public class ModularMySqlClient : ModularDbClient<MySql.Data.MySqlClient.MySqlConnection, MySql.Data.MySqlClient.MySqlCommand, MySql.Data.MySqlClient.MySqlParameter>, IModularDbClient
    {
        public bool SupportOlderConnections = true;

        public override TInterface GetRecordObject<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false)
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
                if (SupportOlderConnections)
                    try { dbConn.Open(); } catch (MySql.Data.MySqlClient.MySqlException ex) { if (!(ex.Message.Contains("Unknown system variable") && dbConn.State == ConnectionState.Open)) throw; }
                else
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

        public override IEnumerable<TInterface> GetRecordList<TInterface, TModel>(string connString, string sSql, IEnumerable<KeyValuePair<string, object>> oParams = null, bool isStoredProc = false)
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
                if (SupportOlderConnections)
                    try { dbConn.Open(); } catch (MySql.Data.MySqlClient.MySqlException ex) { if (!(ex.Message.Contains("Unknown system variable") && dbConn.State == ConnectionState.Open)) throw; }
                else
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

        /*
        public System.Data.IDbConnection GetConnection(string connString)
        {
            return new MySql.Data.MySqlClient.MySqlConnection(connString);
        }
        public System.Data.IDbCommand GetCommand(string cmd, System.Data.IDbConnection conn)
        {
            return new MySql.Data.MySqlClient.MySqlCommand(cmd, (MySql.Data.MySqlClient.MySqlConnection)conn);
        }

        public System.Data.IDbDataParameter AddParameterWithValue(string paramName, object value, System.Data.IDbCommand cmd)
        {
            return ((MySql.Data.MySqlClient.MySqlCommand) cmd).Parameters.AddWithValue(paramName, value);
        }

        public System.Data.IDbDataParameter GetNewParameter()
        {
            return new MySql.Data.MySqlClient.MySqlParameter();
        }
        */
    }
}