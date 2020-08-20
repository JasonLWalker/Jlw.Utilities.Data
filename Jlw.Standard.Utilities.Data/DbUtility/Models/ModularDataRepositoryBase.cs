using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    /*
    public class ModularDataRepositoryBase : ModularDataRepositoryBase<object, object>
    {
        public ModularDataRepositoryBase(IModularDbClient dbClient, string connString) : base(dbClient, connString) { }
    }

    public class ModularDataRepositoryBase<TModel> : ModularDataRepositoryBase<TModel, TModel>
        where TModel : class
    {
        public ModularDataRepositoryBase(IModularDbClient dbClient, string connString) : base(dbClient, connString) { }
    }
    */

    public class ModularDataRepositoryBase<TInterface, TModel> : IModularDataRepositoryBase<TInterface, TModel>
        where TModel : TInterface
    {
        protected string _connString = "";
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
            _connString = connString;
            _dbClient = dbClient ?? new ModularDbClient<NullDbConnection, NullDbCommand, NullDbParameter>();
        }

        #region Internal Members
        protected virtual IDbConnection GetConnection(string connString = null)
        {
            connString = connString ?? _connString;

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


        public virtual TInterface GetRecord(TInterface o) => _dbClient.GetRecordObject<TInterface, TModel>(_connString, _sGetRecord, GetParamsForSql((TModel)o, _sGetRecord), true);
        /*
        {
            if (string.IsNullOrWhiteSpace(_sGetRecord))
                throw new NotImplementedException("Stored Procedure is not defined for GetRecord");

            TModel oReturn = default; 

            using (var sqlConnection = GetConnection()) 
            { 
                sqlConnection.Open(); 
                using (var sqlCommand = GetCommand(_sGetRecord, sqlConnection)) 
                { 
                    PopulateParams(o, sqlCommand);

                    sqlCommand.CommandType = CommandType.StoredProcedure; 

                    using (IDataReader sqlResult = sqlCommand.ExecuteReader()) 
                    { 
                        while (sqlResult.Read()) 
                        { 
                            oReturn = (TModel)Activator.CreateInstance(typeof(TModel), new object[]{sqlResult}); 
                        } 
                    } 
                } 
            }
            return oReturn;
        }
        */

        public virtual IEnumerable<TInterface> GetAllRecords() => _dbClient.GetRecordList<TInterface, TModel>(_connString, _sGetAllRecords, null, isStoredProc: true);
        /*
        {
            if (string.IsNullOrWhiteSpace(_sGetAllRecords))
            {
                throw new NotImplementedException("Stored Procedure is not defined for GetAllRecords");
            }
            
            List<TInterface> oReturn = new List<TInterface>(); 
            { 
                using (var sqlConnection = GetConnection(_connString)) 
                { 
                    sqlConnection.Open(); 
                    using (var sqlCommand = GetCommand(_sGetAllRecords, sqlConnection)) 
                    { 
                        sqlCommand.CommandType = CommandType.StoredProcedure; 
 
                        using (IDataReader sqlResult = sqlCommand.ExecuteReader()) 
                        { 
                            while (sqlResult.Read()) 
                            { 
                                oReturn.Add((TModel)Activator.CreateInstance(typeof(TModel), new object[]{sqlResult})); 
                            } 
                        } 
                    } 
                } 
            } 
            return oReturn; 
        }
        */

        public virtual TInterface InsertRecord(TInterface o)  => _dbClient.GetRecordObject<TInterface, TModel>(_connString, _sInsertRecord, GetParamsForSql((TModel)o, _sInsertRecord), true);
        /*
        { 
            if (string.IsNullOrWhiteSpace(_sInsertRecord))
            {
                throw new NotImplementedException("Stored Procedure is not defined for InsertRecord");
            }
            
            TModel oReturn = default; 
 
            using (var sqlConnection = GetConnection(_connString)) 
            { 
                sqlConnection.Open(); 
                using (var sqlCommand = GetCommand(_sInsertRecord, sqlConnection)) 
                { 
                    PopulateParams(o, sqlCommand);
                    sqlCommand.CommandType = CommandType.StoredProcedure; 
 
                    using (IDataReader sqlResult = sqlCommand.ExecuteReader()) 
                    { 
                        while (sqlResult.Read()) 
                        { 
                            oReturn = (TModel)Activator.CreateInstance(typeof(TModel), new object[]{sqlResult}); 
                        } 
                    } 
                } 
            } 
 
            return oReturn; 
        } 
        */

        public virtual TInterface SaveRecord(TInterface o)  => _dbClient.GetRecordObject<TInterface, TModel>(_connString, _sSaveRecord, GetParamsForSql((TModel)o, _sSaveRecord), true);
        /*
        { 
            if (string.IsNullOrWhiteSpace(_sSaveRecord))
            {
                throw new NotImplementedException("Stored Procedure is not defined for SaveRecord");
            }
            
            TModel oReturn = default; 
 
            using (var sqlConnection = GetConnection(_connString)) 
            { 
                sqlConnection.Open(); 
                using (var sqlCommand = GetCommand(_sSaveRecord, sqlConnection)) 
                { 
                    PopulateParams(o, sqlCommand);
                    sqlCommand.CommandType = CommandType.StoredProcedure; 
 
                    using (IDataReader sqlResult = sqlCommand.ExecuteReader()) 
                    { 
                        while (sqlResult.Read()) 
                        { 
                            oReturn = (TModel)Activator.CreateInstance(typeof(TModel), new object[]{sqlResult}); 
                        } 
                    } 
                } 
            } 
 
            return oReturn; 
        } 
        */
        public virtual TInterface UpdateRecord(TInterface o)  => _dbClient.GetRecordObject<TInterface, TModel>(_connString, _sUpdateRecord, GetParamsForSql((TModel)o, _sUpdateRecord), true);
        /*
        { 
            if (string.IsNullOrWhiteSpace(_sUpdateRecord))
            {
                throw new NotImplementedException("Stored Procedure is not defined for UpdateRecord");
            }
            
            TModel oReturn = default; 
 
            using (var sqlConnection = GetConnection(_connString)) 
            { 
                sqlConnection.Open(); 
                using (var sqlCommand = GetCommand(_sUpdateRecord, sqlConnection)) 
                { 
                    PopulateParams(o, sqlCommand);
                    sqlCommand.CommandType = CommandType.StoredProcedure; 
 
                    using (IDataReader sqlResult = sqlCommand.ExecuteReader()) 
                    { 
                        while (sqlResult.Read()) 
                        { 
                            oReturn = (TModel)Activator.CreateInstance(typeof(TModel), new object[]{sqlResult}); 
                        } 
                    } 
                } 
            } 
 
            return oReturn; 
        } 
        */

        public virtual TInterface DeleteRecord(TInterface o)  => _dbClient.GetRecordObject<TInterface, TModel>(_connString, _sDeleteRecord, GetParamsForSql((TModel)o, _sDeleteRecord), true);
        /*
        { 
            if (string.IsNullOrWhiteSpace(_sDeleteRecord))
            {
                throw new NotImplementedException("Stored Procedure is not defined for DeleteRecord");
            }
            
            TModel oReturn = default; 
 
            { 
                using (var sqlConnection = GetConnection(_connString)) 
                { 
                    sqlConnection.Open(); 
                    using (var sqlCommand = GetCommand(_sDeleteRecord, sqlConnection)) 
                    {
                        PopulateParams(o, sqlCommand);
                        sqlCommand.CommandType = CommandType.StoredProcedure; 
 
                        using (IDataReader sqlResult = sqlCommand.ExecuteReader()) 
                        { 
                            while (sqlResult.Read()) 
                            { 
                                oReturn = (TModel)Activator.CreateInstance(typeof(TModel), new object[]{sqlResult});
                            } 
                        } 
                    } 
                } 
            } 
 
             
            //if (oReturn != null)
            //    return true; 
 
            return oReturn; 
        } 
        */


        public virtual IEnumerable<KeyValuePair<string, string>> GetKvpList() 
        { 
            if (string.IsNullOrWhiteSpace(_sListKeyMemberName) || string.IsNullOrWhiteSpace(_sListDescriptionMemberName))
            {
                throw new NotImplementedException("List Columns are not configured for GetKvpList");
            }

            var aList = GetAllRecords(); 
            List<KeyValuePair<string, string>> oReturn = new List<KeyValuePair<string, string>>();
            foreach(TInterface o in aList)
            {
                oReturn.Add(new KeyValuePair<string, string>(typeof(TModel).GetProperty(_sListKeyMemberName)?.GetValue(o)?.ToString(), typeof(TModel).GetProperty(_sListDescriptionMemberName)?.GetValue(o)?.ToString()));
            }

            return oReturn;
        }

    }
}
