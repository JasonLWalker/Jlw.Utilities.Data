using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    public interface IRepositoryMethodDefinition
    {
        IEnumerable<IDbDataParameter> Parameters { get; }
        RepositoryRecordCallback Callback { get; }
        CommandType CommandType { get; }
        string SqlQuery { get; }
    }
}