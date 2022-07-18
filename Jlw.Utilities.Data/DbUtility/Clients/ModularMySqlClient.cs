using System;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    /// <inheritdoc />
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

    }
}