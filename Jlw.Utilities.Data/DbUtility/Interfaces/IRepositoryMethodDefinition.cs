using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    /// <summary>
    /// Interface IRepositoryMethodDefinition
    /// </summary>
    /// TODO Edit XML Comment Template for IRepositoryMethodDefinition
    public interface IRepositoryMethodDefinition
    {
        IEnumerable<IDbDataParameter> Parameters { get; }
        RepositoryRecordCallback Callback { get; }
        CommandType CommandType { get; }
        string SqlQuery { get; }
    }
}