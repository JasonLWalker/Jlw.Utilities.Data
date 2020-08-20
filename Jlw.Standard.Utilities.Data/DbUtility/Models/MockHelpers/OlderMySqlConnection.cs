using System.Data;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public class OlderMySqlConnection : DbConnectionWrapper<MySql.Data.MySqlClient.MySqlConnection>
    {
        public override void Open()
        {
            try { _dbConn.Open(); } catch (MySql.Data.MySqlClient.MySqlException ex) { if (!(ex.Message.Contains("Unknown system variable") && _dbConn.State == ConnectionState.Open)) throw; }
        }

    }
}