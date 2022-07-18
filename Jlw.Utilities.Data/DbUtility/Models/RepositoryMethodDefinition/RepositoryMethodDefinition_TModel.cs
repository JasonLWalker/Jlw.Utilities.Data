using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
    /// <inheritdoc />
    public class RepositoryMethodDefinition : RepositoryMethodDefinition<object, object>
    {
        public RepositoryMethodDefinition(string sql, IEnumerable<string> paramList = null, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, paramList, callback, returnType) { }

        public RepositoryMethodDefinition(string sql, IEnumerable<IDbDataParameter> paramList = null, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, paramList, callback, returnType) { }

        public RepositoryMethodDefinition(string sql, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback = null, Type returnType=default) : base(sql, paramList, callback, returnType) { }

        public RepositoryMethodDefinition(string sql, CommandType cmdType = CommandType.Text, IEnumerable<string> paramList = null, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, cmdType, paramList, callback, returnType) {}

        public RepositoryMethodDefinition(string sql, CommandType cmdType, IEnumerable<IDbDataParameter> paramList = null, RepositoryRecordCallback callback = null) : base(sql, cmdType, paramList, callback) { }

        public RepositoryMethodDefinition(string sql, CommandType cmdType, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback = null) : base(sql, cmdType, paramList, callback) { }
    }


    /// <inheritdoc />
    public class RepositoryMethodDefinition<TModel> : RepositoryMethodDefinition<TModel, TModel>
    {
        public RepositoryMethodDefinition(string sql, IEnumerable<string> paramList = null, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, paramList, callback, returnType) { }
        public RepositoryMethodDefinition(string sql, IEnumerable<IDbDataParameter> paramList = null, RepositoryRecordCallback callback = null) : base(sql, paramList, callback) { }

        public RepositoryMethodDefinition(string sql, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback = null) : base(sql, paramList, callback) { }

        public RepositoryMethodDefinition(string sql, CommandType cmdType = CommandType.Text, IEnumerable<string> paramList = null, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, cmdType, paramList, callback, returnType) { }
        public RepositoryMethodDefinition(string sql, CommandType cmdType, IEnumerable<IDbDataParameter> paramList = null, RepositoryRecordCallback callback = null) : base(sql, cmdType, paramList, callback) { }

        public RepositoryMethodDefinition(string sql, CommandType cmdType, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback = null) : base(sql, cmdType, paramList, callback) { }
    }


}
