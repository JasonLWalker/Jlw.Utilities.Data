using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using Jlw.Utilities.Data.DbUtility;


/****************************************************************************\
 *
 * Jlw.Utilities.Data.DataTables 
 * 
 * For use with the jQuery.DataTables v1.10 and higher. 
 * jQuery.DataTables v1.9 and earlier uses different member names and is not
 * compatible with this class.
 * 
 * Copyright 2013-2020 Jason L. Walker
 *
\****************************************************************************/

namespace Jlw.Utilities.Data.DataTables
{
    public class DataTablesBase : IDataTablesBase
    {
        protected IDataTablesInput Input;
        protected IDataTablesOutput Output;
        protected IModularDbClient _dbClient;
        public IEnumerable<object> Data => Output?.data;

        public bool UseOrderedPaging { get; set; } = false;

        protected Dictionary<string, string> SortColumns { get; set; } // Internal list to hold list of columns that can be sorted on.
        protected Dictionary<string, string> SearchColumns { get; set; } // Internal list to hold list of columns that can be sorted on.        
        /// <summary>
        /// Internal list to hold list of columns that are valid. 
        /// Will also be used to validate column names passed in and will not allow operations to occur on columns not added to this list.
        /// </summary>
        /// <value>
        /// Represents what columns will appear in the output. 
        /// </value>
        /// TODO Edit XML Comment Template for ValidColumns
        protected Dictionary<string, string> ValidColumns { get; set; } // 
        internal Dictionary<string, string> ExtraParams { get; set; } // Internal list to hold list of extra SQL paramaters to initialize.
//        protected string SqlConnectionString { get; set; }  // Internal string to hold the SQL Connection string

        private static readonly char[] cTrim = { ' ', ',', '\t', '\n', '\r', '|' };	// Array of characters to strip as whitespace during SQL Build operations.

        internal string GlobalFilter = "";

        internal string SqlQueryDebug;

        internal bool bDebug = false;
        protected void Initialize(IDataTablesInput input = null, IModularDbClient dbClient = null)
        {
            _dbClient = dbClient;
            Input = input ?? new DataTablesInput();
            Output = new DataTablesOutput(Input);

            SortColumns = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);     // Initialize Dictionary keys as case insensitive
            SearchColumns = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);   // Initialize Dictionary keys as case insensitive
            ValidColumns = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);    // Initialize Dictionary keys as case insensitive
            GlobalFilter = "";                                                                  // Initialize global filter SQL Fragment
            ExtraParams = new Dictionary<string, string>();	                                    // Initialize Dictionary keys as case sensitive

            //Output
        }

        public DataTablesBase(IDataTablesInput input = null, IModularDbClient dbClient = null)
        {
            Initialize(input, dbClient);
        }


        public void SetDebug(bool b)
        {
            bDebug = b;
        }

        /// <summary>
        /// Adds a Column to the Valid Column list. 
        /// </summary>
        /// <param name="columnName">The name of the column. This will be used as both the column name in the output, and the column name in the generated SQL Query.</param>
        /// <param name="sqlFragment">The fragment of SQL code used to generate this column. This can be as simple as a table column name, or as complex as a SQL subquery.</param>
        public void AddColumn(string columnName, string sqlFragment = null)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                throw new ArgumentException("Column Name is required.", nameof(columnName));

            if (string.IsNullOrWhiteSpace(sqlFragment))
                sqlFragment = "[" + columnName + "]";
                //throw new ArgumentException("SQL Fragment is required.", nameof(sqlFragment));

            Regex r = new Regex(@"^\w+$");
            if (!r.IsMatch(columnName))
                throw new ArgumentException("Column Name must be Alphanumeric with no spaces or special characters.", nameof(columnName));

            if (ValidColumns?.ContainsKey(columnName) ?? false)
                throw new ArgumentException("A Column with the name '" + columnName + "' already exists.", nameof(columnName));

            ValidColumns?.Add(columnName, sqlFragment);

        }

        public void SetGlobalFilter(string sqlFragment)
        {
            if (string.IsNullOrWhiteSpace(sqlFragment))
                throw new ArgumentException("SQL Fragment is required.", nameof(sqlFragment));

            GlobalFilter = sqlFragment;

        }

        public void AddExtraParams(string columnName, string sqlFragment)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                throw new ArgumentException("Parameter Name is required.", nameof(columnName));

            if (ExtraParams?.ContainsKey(columnName) ?? false)
                throw new ArgumentException("A Parameter with the name '" + columnName + "' already exists.", nameof(columnName));

            if (sqlFragment == null)
            {
                ExtraParams?.Add(columnName, null);
                return;
            }

            if (string.IsNullOrWhiteSpace(sqlFragment))
                throw new ArgumentException("SQL Fragment is required.", nameof(sqlFragment));

            Regex r = new Regex(@"^\w+$");
            if (!r.IsMatch(columnName))
                throw new ArgumentException("Parameter Name must be Alphanumeric with no spaces or special characters.", nameof(columnName));

            ExtraParams?.Add(columnName, sqlFragment);
        }

        public void AddSearchColumns(string columnName, string sqlFragment =  null)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                throw new ArgumentException("Column Name is required.", nameof(columnName));

            if (string.IsNullOrWhiteSpace(sqlFragment))
                sqlFragment = "[" + columnName + "]";

            Regex r = new Regex(@"^\w+$");
            if (!r.IsMatch(columnName))
                throw new ArgumentException("Column Name must be Alphanumeric with no spaces or special characters.", nameof(columnName));

            if (SearchColumns?.ContainsKey(columnName) ?? false)
                throw new ArgumentException("A Column with the name '" + columnName + "' already exists.", nameof(columnName));

            SearchColumns?.Add(columnName, sqlFragment);

        }

        public void AddSortColumns(string columnName, string sqlFragment = null)
        {
            if (string.IsNullOrWhiteSpace(columnName))
                throw new ArgumentException("Column Name is required.", nameof(columnName));

            if (string.IsNullOrWhiteSpace(sqlFragment))
                sqlFragment = columnName;

            Regex r = new Regex(@"^\w+$");
            if (!r.IsMatch(columnName))
                throw new ArgumentException("Column Name must be Alphanumeric with no spaces or special characters.", nameof(columnName));

            if (SortColumns?.ContainsKey(columnName) ?? false)
                throw new ArgumentException("A Column with the name '" + columnName + "' already exists.", nameof(columnName));

            SortColumns?.Add(columnName, sqlFragment);

        }

        public virtual IDataTablesOutput FetchQuery(string connString, string sSql)
        {
            using (IDbConnection conn = _dbClient.GetConnection(connString))
            {
                conn.Open();
                string sSearch = "%" + Input?.search?.value + "%";

                // Retrieve filtered and paginated data
                SqlQueryDebug = sSql;
                using (var cmd = _dbClient.GetCommand(sSql, conn))
                {
                    _dbClient.AddParameterWithValue("@sSearch", sSearch, cmd);
                    _dbClient.AddParameterWithValue("@nRowStart", (Input?.start ?? 0), cmd); // SQL offset begins with 0
                    _dbClient.AddParameterWithValue("@nPageSize", (Input?.length ?? 10), cmd);
                    AddParamsToSqlCommand(cmd);

                    using (IDataReader result = cmd.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            ((List<object>)Output.data).Add(BuildRow(result));
                            Output.recordsFiltered = DataUtility.ParseInt(result, "jlwDtFilteredCount");
                            Output.recordsTotal = DataUtility.ParseInt(result, "jlwDtTotalCount");
                        }
                    }
                }
            }

            if (bDebug)
                Output.debug = SqlQueryDebug;

            return Output;
        }

        public virtual IDataTablesOutput FetchData(string connString, string tables)
        {
            //int n = 0;
            string sqlColumns = BuildColumns();

            if (string.IsNullOrWhiteSpace(sqlColumns)) return Output;

            // Uses standard TSQL Queries instead of LINQ due to having to build query on the fly.
            using (IDbConnection conn = _dbClient.GetConnection(connString))
            {
                conn.Open();
                var sql = "";
                sql = BuildQuery(tables);

                string sSearch = "%" + Input?.search?.value + "%";

                // Retrieve filtered and paginated data
                using (var cmd = _dbClient.GetCommand(sql, conn))
                {
                    _dbClient.AddParameterWithValue("@sSearch", sSearch, cmd);
                    if (UseOrderedPaging)
                    {
                        _dbClient.AddParameterWithValue("@nRowStart", (Input?.start ?? 0) + 1, cmd); // Correct for SQL rows beginning with 1 and not 0
                        _dbClient.AddParameterWithValue("@nRowEnd", Input?.start + Input?.length, cmd); // Correct for SQL rows beginning with 1 and not 0
                    }
                    else
                    {
                        _dbClient.AddParameterWithValue("@nRowStart", (Input?.start ?? 0), cmd); // SQL offset begins with 0
                        _dbClient.AddParameterWithValue("@nPageSize", (Input?.length ?? 10), cmd);
                    }
                    AddParamsToSqlCommand(cmd);
                    
                    using (IDataReader result = cmd.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            ((List<object>)Output.data).Add(BuildRow(result));
                            Output.recordsFiltered = DataUtility.ParseInt(result, "jlwDtFilteredCount");
                            Output.recordsTotal = DataUtility.ParseInt(result, "jlwDtTotalCount");
                        }
                    }
                }
                SqlQueryDebug = sql;
                
                if (bDebug)
                    Output.debug = SqlQueryDebug;

                return Output;

            }
        }

        internal void AddParamsToSqlCommand(IDbCommand cmd)
        {
            foreach (KeyValuePair<string, string> o in ExtraParams)
            {
                _dbClient.AddParameterWithValue(o.Key, o.Value, cmd); // Initialize any additional parameters
            }

            foreach (IDbDataParameter parameter in cmd.Parameters)
            {
                if (parameter.Value == null)
                {
                    parameter.Value = DBNull.Value;
                }
            }
        }

        internal virtual string BuildQuery(string tables)
        {
            string sqlColumns = BuildColumns();
            string sqlSort = BuildSort();
            string sqlCriteria = BuildFilter();
            string sqlInner = BuildInnerQuery(tables, sqlSort, sqlCriteria);

            return "DECLARE @jlwDtTotalCount int = (SELECT COUNT(*) FROM " + tables + ");" + BuildContraint(sqlColumns, sqlInner);
        }

        internal virtual string BuildFilter()
        {
            string s = "";
            if (string.IsNullOrWhiteSpace(Input?.search?.value))
                return GlobalFilter ?? "";

            foreach (KeyValuePair<string, string> o in SearchColumns)
            {
                s += o.Value + " LIKE @sSearch Collate SQL_Latin1_General_CP1_CI_AS|";
            }

            s = s.Trim(cTrim);

            if (string.IsNullOrWhiteSpace(s))
                return GlobalFilter ?? "";

            var r = s.Replace("|", " OR ");

            if (string.IsNullOrWhiteSpace(GlobalFilter))
                return r;

            return "(" + GlobalFilter + ") AND (" + r + ")";
        }

        internal virtual string BuildSort()
        {
            int orderCol = 0;
            string orderBy = "";
            string orderDir = " asc";


            if (Input?.order?.Any() ?? false)
            {
                var cols = Input?.columns?.Select(o => o).ToList();
                var sort = Input?.order?.ToArray()[0];

                if (sort != null)
                {
                    orderCol = sort.column;
                    orderDir = sort.dir == "desc" ? " desc" : " asc";
                    if (cols?.Count >= orderCol)
                        orderBy = cols[orderCol]?.data;
                }
                if (string.IsNullOrWhiteSpace(orderBy) || !ValidColumns.ContainsKey(orderBy))
                    orderBy = "";
            }


            // Return first valid column if SortColumns is not set
            if (SortColumns?.Count < 1)
            {
                return ValidColumns?.Values.FirstOrDefault() + orderDir;
            }

            // Return first sort column if sOrderBy is not set
            if (string.IsNullOrEmpty(orderBy))
                return SortColumns?.Values.FirstOrDefault() + orderDir;


            // Return first sort column if sOrderBy is not in SortColumns list
            if (!SortColumns?.ContainsKey(orderBy) ?? false) return SortColumns?.Values.First() + orderDir;

            // Return sorting SQL parameter
            string s = "";
            SortColumns?.TryGetValue(orderBy, out s);

            return s + orderDir;
        }

        internal virtual string BuildColumns()
        {
            if (ValidColumns?.Count < 1)
                throw new ArgumentException("at least one element is required", "ValidColumns");

            string s = "";
            foreach (KeyValuePair<string, string> o in ValidColumns)
            {
                s += "[" + o.Key + "], ";
            }
            return s.Trim(cTrim);
        }

        internal virtual object BuildRow(IDataRecord row)
        {
            // Create a new Dictionary to hold column data for this row
            var o = new Dictionary<string, string>();
            // Initialize o with column names from ValidColumns with Empty string so that all columns are accounted for.
            foreach (KeyValuePair<string, string> p in ValidColumns)
            {
                o[p.Key] = "";
            }
            // Add all columns from row to Dictionary o
            for (int i = 0; i < row?.FieldCount; i++)
            {
                object v = row.IsDBNull(i) ? "" : row.GetValue(i);
                o[row.GetName(i)] = v?.ToString();
            }
            // return data
            return o;
        }

        internal virtual string BuildInnerQuery(string sTables, string sSortSQL, string sCriteriaSQL)
        {
            if (ValidColumns?.Count < 1)
                throw new ArgumentException("at least one element is required", "ValidColumns");

            string s = @"SELECT ";
            foreach (KeyValuePair<string, string> o in ValidColumns)
            {
                if (o.Value == "[" + o.Key + "]" || o.Value == o.Key)
                    s += "[" + o.Key + "], ";
                else
                    s += o.Value + " as [" + o.Key + "], ";
            }
            s = s.Trim(cTrim);

            s += ", COUNT(*) OVER () AS jlwDtFilteredCount, @jlwDtTotalCount AS jlwDtTotalCount";

            if (UseOrderedPaging)
            {
                s += ", ROW_NUMBER() OVER (ORDER BY " + sSortSQL + ") as rownum";
            }
            s += " FROM " + sTables + ((string.IsNullOrWhiteSpace(sCriteriaSQL)) ? "" : " WHERE " + sCriteriaSQL);

            if (!UseOrderedPaging)
            {
                s += " ORDER BY " + sSortSQL;
            }
            return s;
        }

        internal virtual string BuildContraint(string columns, string sqlInner)
        {
            string s;

            if (UseOrderedPaging)
            {
                s="WITH ORDERED AS ( " + sqlInner + " ) SELECT " + columns + ", jlwDtFilteredCount, jlwDtTotalCount FROM ORDERED";
                if (Input?.length > 0 || Input?.start > 0)
                    s += " WHERE rownum BETWEEN @nRowStart AND @nRowEnd";
            }
            else
            {
                s = sqlInner + @" OFFSET @nRowStart ROWS FETCH NEXT @nPageSize ROWS ONLY";
            }
            return s;
        }

    }
}
