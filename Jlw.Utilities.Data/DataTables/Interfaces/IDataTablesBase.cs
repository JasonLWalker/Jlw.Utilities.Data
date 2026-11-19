using System.Collections.Generic;

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
    /// <summary>
    /// Interface IDataTablesBase
    /// </summary>
    /// TODO Edit XML Comment Template for IDataTablesBase
    public interface IDataTablesBase
    {
        /// <summary>
        /// Gets or sets the command timeout value, in seconds, for database operations.
        /// </summary>
        /// <remarks>
        /// This property specifies the maximum duration a database command is allowed to execute before timing out.
        /// </remarks>
        int CommandTimeout { get; set; }

        /// <summary>
        /// Gets the collection of data objects to be used in the DataTables output.
        /// </summary>
        /// <remarks>
        /// This property typically represents the data rows returned from a query or other data source.
        /// </remarks>
        IEnumerable<object> Data { get; }

        /// <summary>
        /// Gets or sets a value indicating whether ordered paging is used in the DataTables query.
        /// </summary>
        /// <value>
        /// <c>true</c> if ordered paging is enabled; otherwise, <c>false</c>.
        /// </value>
        bool UseOrderedPaging { get; set; }

        /// <summary>
        /// Adds a column to the list of valid columns for the DataTables query.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column. This will be used as both the column name in the output
        /// and the column name in the generated SQL query.
        /// </param>
        /// <param name="sqlFragment">
        /// The SQL fragment used to generate the column. This can be a simple table column name
        /// or a more complex SQL expression. If not provided, the column name will be used as the default.
        /// </param>
        void AddColumn(string columnName, string sqlFragment = null);
        
        /// <summary>
        /// Adds an extra parameter to the DataTables query.
        /// </summary>
        /// <param name="columnName">
        /// The name of the parameter. This must be alphanumeric with no spaces or special characters.
        /// </param>
        /// <param name="sqlFragment">
        /// The SQL fragment associated with the parameter. This can be a simple value or a more complex SQL expression.
        /// </param>
        void AddExtraParams(string columnName, string sqlFragment);
        
        /// <summary>
        /// Adds a column to the list of searchable columns for the DataTables query.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column to be added. This must be alphanumeric with no spaces or special characters.
        /// </param>
        /// <param name="sqlFragment">
        /// The SQL fragment used to represent the column in the query. If not provided, the column name will be used as the default.
        /// </param>
        void AddSearchColumns(string columnName, string sqlFragment = null);

        /// <summary>
        /// Adds a column to the list of sortable columns for the DataTables query.
        /// </summary>
        /// <param name="columnName">
        /// The name of the column to be added. This must be alphanumeric with no spaces or special characters.
        /// </param>
        /// <param name="sqlFragment">
        /// The SQL fragment used to represent the column in the query. If not provided, the column name will be used as the default.
        /// </param>
        void AddSortColumns(string columnName, string sqlFragment = null);
        
        /// <summary>
        /// Fetches data from the specified tables using the provided connection string.
        /// </summary>
        /// <param name="connString">
        /// The connection string used to connect to the database.
        /// </param>
        /// <param name="tables">
        /// A comma-separated list of table names to query data from.
        /// </param>
        /// <returns>
        /// An <see cref="IDataTablesOutput"/> object containing the fetched data, 
        /// including metadata such as total records, filtered records, and any errors.
        /// </returns>
        IDataTablesOutput FetchData(string connString, string tables);


        /// <summary>
        /// Executes a query against the database and retrieves the result as an <see cref="IDataTablesOutput"/> object.
        /// </summary>
        /// <param name="connString">
        /// The connection string used to connect to the database.
        /// </param>
        /// <param name="sSql">
        /// The SQL query to be executed.
        /// </param>
        /// <returns>
        /// An <see cref="IDataTablesOutput"/> object containing the fetched data, 
        /// including metadata such as total records, filtered records, and any errors.
        /// </returns>
        IDataTablesOutput FetchQuery(string connString, string sSql);


        /// <summary>
        /// Enables or disables debug mode for the DataTables query.
        /// </summary>
        /// <param name="b">
        /// A boolean value indicating whether debug mode should be enabled. 
        /// Pass <c>true</c> to enable debug mode or <c>false</c> to disable it.
        /// </param>
        void SetDebug(bool b);
        
        /// <summary>
        /// Sets a global filter for the DataTables query.
        /// </summary>
        /// <param name="sqlFragment">
        /// The SQL fragment representing the global filter. This can be a simple condition or a more complex SQL expression.
        /// </param>
        void SetGlobalFilter(string sqlFragment);
    }
}