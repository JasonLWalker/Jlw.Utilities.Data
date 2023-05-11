using System;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
	public class QueryMethodDefinition<TModel> : RepositoryMethodDefinition<TModel, TModel>
	{
		public QueryMethodDefinition(string sql, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, CommandType.Text, (IEnumerable<string>)null, callback, returnType) { }

		public QueryMethodDefinition(string sql, IEnumerable<string> paramList, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, CommandType.Text, paramList, callback, returnType) { }

		public QueryMethodDefinition(string sql, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, CommandType.Text, paramList, callback, returnType) { }
	}

	public class QueryMethodDefinition<TInterface, TModel> : RepositoryMethodDefinition<TInterface, TModel>
	{
		public QueryMethodDefinition(string sql, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, CommandType.Text, (IEnumerable<string>)null, callback, returnType) { }

		public QueryMethodDefinition(string sql, IEnumerable<string> paramList, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, CommandType.Text, paramList, callback, returnType) { }

		public QueryMethodDefinition(string sql, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, CommandType.Text, paramList, callback, returnType) { }
	}
}