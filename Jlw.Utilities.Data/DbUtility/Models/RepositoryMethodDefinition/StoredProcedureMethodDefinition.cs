using System;
using System.Collections.Generic;
using System.Data;

namespace Jlw.Utilities.Data.DbUtility
{
	public class StoredProcedureMethodDefinition<TModel> : RepositoryMethodDefinition<TModel, TModel>
	{
		public StoredProcedureMethodDefinition(string sql, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, CommandType.StoredProcedure, (IEnumerable<string>)null, callback, returnType) { }

		public StoredProcedureMethodDefinition(string sql, IEnumerable<string> paramList, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, CommandType.StoredProcedure, paramList, callback, returnType) { }

		public StoredProcedureMethodDefinition(string sql, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, CommandType.StoredProcedure, paramList, callback, returnType) { }
	}
	public class StoredProcedureMethodDefinition<TInterface, TModel> : RepositoryMethodDefinition<TInterface, TModel>
	{
		public StoredProcedureMethodDefinition(string sql, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, CommandType.StoredProcedure, (IEnumerable<string>)null, callback, returnType) { }

		public StoredProcedureMethodDefinition(string sql, IEnumerable<string> paramList, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, CommandType.StoredProcedure, paramList, callback, returnType) { }

		public StoredProcedureMethodDefinition(string sql, IEnumerable<KeyValuePair<string, object>> paramList, RepositoryRecordCallback callback = null, Type returnType = default) : base(sql, CommandType.StoredProcedure, paramList, callback, returnType) { }
	}
}