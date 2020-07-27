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

        protected readonly string _sListKeyColumn = "";
        protected readonly string _sListDescriptionColumn = "";

        protected readonly string _spGetRecord = "";
        protected string _spGetAllRecords = "";
        protected string _spSaveRecord = "";
        protected string _spInsertRecord = "";
        protected string _spUpdateRecord = "";
        protected string _spDeleteRecord = "";


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


        public virtual TInterface GetRecord(TInterface o)
        {
            if (string.IsNullOrWhiteSpace(_spGetRecord))
                throw new NotImplementedException("Stored Procedure is not defined for GetRecord");

            TModel oReturn = default; 
 
            using (var sqlConnection = GetConnection()) 
            { 
                sqlConnection.Open(); 
                using (var sqlCommand = GetCommand(_spGetRecord, sqlConnection)) 
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

        public virtual IEnumerable<TInterface> GetAllRecords()
        {
            if (string.IsNullOrWhiteSpace(_spGetAllRecords))
            {
                throw new NotImplementedException("Stored Procedure is not defined for GetAllRecords");
            }
            
            List<TInterface> oReturn = new List<TInterface>(); 
            { 
                using (var sqlConnection = GetConnection(_connString)) 
                { 
                    sqlConnection.Open(); 
                    using (var sqlCommand = GetCommand(_spGetAllRecords, sqlConnection)) 
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

        public virtual TInterface InsertRecord(TInterface o) 
        { 
            if (string.IsNullOrWhiteSpace(_spInsertRecord))
            {
                throw new NotImplementedException("Stored Procedure is not defined for InsertRecord");
            }
            
            TModel oReturn = default; 
 
            using (var sqlConnection = GetConnection(_connString)) 
            { 
                sqlConnection.Open(); 
                using (var sqlCommand = GetCommand(_spInsertRecord, sqlConnection)) 
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
 
        public virtual TInterface SaveRecord(TInterface o) 
        { 
            if (string.IsNullOrWhiteSpace(_spSaveRecord))
            {
                throw new NotImplementedException("Stored Procedure is not defined for SaveRecord");
            }
            
            TModel oReturn = default; 
 
            using (var sqlConnection = GetConnection(_connString)) 
            { 
                sqlConnection.Open(); 
                using (var sqlCommand = GetCommand(_spSaveRecord, sqlConnection)) 
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

        public virtual TInterface UpdateRecord(TInterface o) 
        { 
            if (string.IsNullOrWhiteSpace(_spUpdateRecord))
            {
                throw new NotImplementedException("Stored Procedure is not defined for UpdateRecord");
            }
            
            TModel oReturn = default; 
 
            using (var sqlConnection = GetConnection(_connString)) 
            { 
                sqlConnection.Open(); 
                using (var sqlCommand = GetCommand(_spUpdateRecord, sqlConnection)) 
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


        public virtual bool DeleteRecord(TInterface o) 
        { 
            if (string.IsNullOrWhiteSpace(_spDeleteRecord))
            {
                throw new NotImplementedException("Stored Procedure is not defined for DeleteRecord");
            }
            
            TModel oReturn = default; 
 
            { 
                using (var sqlConnection = GetConnection(_connString)) 
                { 
                    sqlConnection.Open(); 
                    using (var sqlCommand = GetCommand(_spDeleteRecord, sqlConnection)) 
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
 
             
            if (oReturn != null)
                return true; 
 
            return false; 
        } 
 

        public virtual IEnumerable<KeyValuePair<string, string>> GetKvpList() 
        { 
            if (string.IsNullOrWhiteSpace(_sListKeyColumn) || string.IsNullOrWhiteSpace(_sListDescriptionColumn))
            {
                throw new NotImplementedException("List Columns are not configured for GetKvpList");
            }

            var aList = GetAllRecords(); 
            List<KeyValuePair<string, string>> oReturn = new List<KeyValuePair<string, string>>();
            foreach(TInterface o in aList)
            {
                oReturn.Add(new KeyValuePair<string, string>(DataUtility.ParseString(o, _sListKeyColumn), DataUtility.ParseString(o, _sListDescriptionColumn)));
            }

            return oReturn;
        } 
 


    }
}
