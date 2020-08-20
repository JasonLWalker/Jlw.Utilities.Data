using System.Data;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class OlderMySqlConnection : DbConnectionWrapper<MySql.Data.MySqlClient.MySqlConnection, MySql.Data.MySqlClient.MySqlCommand>, IDbConnection
    {
        public override void Open()
        {
            try { DbConn.Open(); } catch (MySql.Data.MySqlClient.MySqlException ex) { if (!(ex.Message.Contains("Unknown system variable") && DbConn.State == ConnectionState.Open)) throw; }
        }

    }
}