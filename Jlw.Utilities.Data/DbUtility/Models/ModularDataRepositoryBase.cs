using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Jlw.Utilities.Data.DbUtility
{
    /// <inheritdoc />
    public class ModularDataRepositoryBase<TModel> : ModularDataRepositoryBase<TModel, TModel>
    {
        public ModularDataRepositoryBase(IModularDbClient dbClient, string connString) : base(dbClient, connString) { }
    }

    /// <inheritdoc />
    public class ModularDataRepositoryBase<TInterface, TModel> : IModularDataRepositoryBase<TInterface, TModel>
        where TModel : TInterface
    {
        protected DbConnectionStringBuilder _builder { get; } //return _dbClient.CreateConnectionBuilder(); 
        

        protected string _connString => _builder.ConnectionString;
        protected IModularDbClient _dbClient;

        protected string _sListKeyMemberName = "";
        protected string _sListDescriptionMemberName = "";


        protected string _sGetRecord = "";
        protected string _sGetAllRecords = "";
        protected string _sSaveRecord = "";
        protected string _sInsertRecord = "";
        protected string _sUpdateRecord = "";
        protected string _sDeleteRecord = "";


        public ModularDataRepositoryBase(IModularDbClient dbClient, string connString)
        {
            _dbClient = dbClient ?? new ModularDbClient<NullDbConnection, NullDbCommand, NullDbParameter>();
            _builder = _dbClient.GetConnectionBuilder(connString);
        }

        #region Internal Members
        protected virtual IDbConnection GetConnection(string connString = null)
        {
            connString ??= _connString;

            if (string.IsNullOrWhiteSpace(connString))
            {
                throw new ArgumentException("Invalid Connection String. Connection string may not be empty or null.");
            }

            IDbConnection dbConn = _dbClient?.GetConnection(connString);

            if (dbConn == null)
            {
                throw new InvalidOperationException("Unable to retrieve a valid database connection.");
            }

            return dbConn;
        }
        protected virtual IDbCommand GetCommand(string sqlString, IDbConnection dbConn)
        {
            if (string.IsNullOrWhiteSpace(sqlString))
            {
                throw new ArgumentException("Invalid command string. SQL command may not be empty or null.");
            }

            IDbCommand dbCmd = _dbClient?.GetCommand(sqlString, dbConn);

            if (dbCmd == null)
            {
                throw new InvalidOperationException("Unable to initialize database command.");
            }

            return dbCmd;
        }

        protected virtual IDbDataParameter AddParameterWithValue(string paramName, object value, IDbCommand dbCmd)
        {
            return _dbClient.AddParameterWithValue(paramName, value, dbCmd);
        }

        protected virtual IEnumerable<KeyValuePair<string, object>> GetParamsForSql(TInterface o, string sSql)
        {
            var aReturn = new List<KeyValuePair<string, object>>();
            PropertyInfo[] properties = typeof(TInterface).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (PropertyInfo p in properties)
            {
                // Don't process unreadable properties
                if (!p.CanRead) { continue; }

                // Don't process properties without a public get method
                MethodInfo mget = p.GetGetMethod(false);
                if (mget == null) { continue; }

                var val = p.GetValue(o);
                if (val != null)
                {
                    // Add parameter with lowercase member name and the current property value
                    //AddParameterWithValue(p.Name.ToLower(), p.GetValue(o, null), dbCmd);
                    aReturn.Add(new KeyValuePair<string, object>(p.Name, val));
                }
            }

            return aReturn;
        }

        protected virtual void PopulateParams(TInterface o, IDbCommand dbCmd)
        {
            PropertyInfo[] properties = typeof(TInterface).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                //.Where(o => o.CanRead);

            foreach (PropertyInfo p in properties)
            {
                // Don't process unreadable properties
                if (!p.CanRead) { continue; }

                // Don't process properties without a public get method
                MethodInfo mget = p.GetGetMethod(false);
                if (mget == null) { continue; }

                if (p.GetValue(o) != null)
                {
                    // Add parameter with lowercase member name and the current property value
                    AddParameterWithValue(p.Name.ToLower(), p.GetValue(o, null), dbCmd);
                }
            }
        }
        #endregion

        public virtual TInterface GetRecord(TInterface o) => _dbClient.GetRecordObject<TModel>(o, _connString, new RepositoryMethodDefinition<TInterface, TModel>(_sGetRecord, CommandType.StoredProcedure, GetParamsForSql((TModel)o, _sGetRecord)));
        public virtual IEnumerable<TInterface> GetAllRecords() => (IEnumerable<TInterface>)_dbClient.GetRecordList<TModel>(default, _connString, new RepositoryMethodDefinition<TInterface, TModel>(_sGetAllRecords, CommandType.StoredProcedure, new string[]{}));

        public virtual TInterface InsertRecord(TInterface o)  => _dbClient.GetRecordObject<TModel>(o, _connString, new RepositoryMethodDefinition<TInterface, TModel>(_sInsertRecord, CommandType.StoredProcedure, GetParamsForSql((TModel)o, _sInsertRecord)));

        public virtual TInterface SaveRecord(TInterface o)  => _dbClient.GetRecordObject<TModel>(o, _connString, new RepositoryMethodDefinition<TInterface, TModel>(_sSaveRecord, CommandType.StoredProcedure, GetParamsForSql((TModel)o, _sSaveRecord)));

        public virtual TInterface UpdateRecord(TInterface o)  => _dbClient.GetRecordObject<TModel>(o, _connString, new RepositoryMethodDefinition<TInterface, TModel>(_sUpdateRecord, CommandType.StoredProcedure, GetParamsForSql((TModel)o, _sUpdateRecord)));

        public virtual TInterface DeleteRecord(TInterface o)  => _dbClient.GetRecordObject<TModel>(o, _connString, new RepositoryMethodDefinition<TInterface, TModel>(_sDeleteRecord, CommandType.StoredProcedure, GetParamsForSql((TModel)o, _sDeleteRecord)));


        public virtual IEnumerable<KeyValuePair<string, string>> GetKvpList(string keyMember=null, string descMember = null)
        {
            string key = keyMember ?? _sListKeyMemberName;
            string desc = descMember ?? _sListDescriptionMemberName;

            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(desc))
            {
                throw new NotImplementedException("List Columns are not configured for GetKvpList");
            }

            var aList = GetAllRecords(); 
            List<KeyValuePair<string, string>> oReturn = new List<KeyValuePair<string, string>>();
            foreach(TInterface o in aList)
            {
                oReturn.Add(new KeyValuePair<string, string>(DataUtility.Parse<string>(o, key), DataUtility.Parse<string>(o, desc)));
                //oReturn.Add(new KeyValuePair<string, string>(typeof(TModel).GetProperty(_sListKeyMemberName)?.GetValue(o)?.ToString(), typeof(TModel).GetProperty(_sListDescriptionMemberName)?.GetValue(o)?.ToString()));
            }

            return oReturn;
        }

    }
}
