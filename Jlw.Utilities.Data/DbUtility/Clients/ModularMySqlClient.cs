using System;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    public class ModularMySqlClient : ModularDbClient<MySql.Data.MySqlClient.MySqlConnection, MySql.Data.MySqlClient.MySqlCommand, MySql.Data.MySqlClient.MySqlParameter, MySql.Data.MySqlClient.MySqlConnectionStringBuilder>, IModularDbClient
    {
        public bool SupportOlderConnections = true;

        protected override void OpenConnection(IDbConnection dbConn)
        {
            if (SupportOlderConnections)
                try { base.OpenConnection(dbConn); } catch (MySql.Data.MySqlClient.MySqlException ex) { if (!(ex.Message.Contains("Unknown system variable") && dbConn.State == ConnectionState.Open)) throw; }
            else
                base.OpenConnection(dbConn);
        }

        /*
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
                    
                    //if (isStoredProc)
                    //    dbCmd.CommandType = CommandType.StoredProcedure; 

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
                    
                    //if (isStoredProc)
                    //    dbCmd.CommandType = CommandType.StoredProcedure; 

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
        */
    }
}