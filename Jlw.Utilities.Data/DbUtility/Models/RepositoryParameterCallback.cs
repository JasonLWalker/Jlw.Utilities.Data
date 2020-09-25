using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    public delegate object RepositoryParameterCallback (object o, IDbDataParameter param);
}