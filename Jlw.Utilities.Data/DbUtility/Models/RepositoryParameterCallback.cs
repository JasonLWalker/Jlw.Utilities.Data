using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    /// <summary>
    /// Delegate RepositoryParameterCallback
    /// </summary>
    /// <param name="o">The object referenced.</param>
    /// <param name="param">The database parameters passed in.</param>
    /// <returns>System.Object</returns>
    /// TODO Edit XML Comment Template for RepositoryParameterCallback
    public delegate object RepositoryParameterCallback (object o, IDbDataParameter param);
}