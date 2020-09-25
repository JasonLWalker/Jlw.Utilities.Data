using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    // declare a delegate

    public class RepositoryMethodDefinition<TModel> : RepositoryMethodDefinition<TModel, TModel>
    {
        public RepositoryMethodDefinition(string sql, IEnumerable<IDbDataParameter> paramList = null, RepositoryRecordCallback callback = null) : base(sql, paramList, callback) { }

        public RepositoryMethodDefinition(string sql, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback = null) : base(sql, paramList, callback) { }

        public RepositoryMethodDefinition(string sql, CommandType cmdType, IEnumerable<IDbDataParameter> paramList = null, RepositoryRecordCallback callback = null) : base(sql, cmdType, paramList, callback) { }

        public RepositoryMethodDefinition(string sql, CommandType cmdType, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback = null) : base(sql, cmdType, paramList, callback) { }
    }


}
