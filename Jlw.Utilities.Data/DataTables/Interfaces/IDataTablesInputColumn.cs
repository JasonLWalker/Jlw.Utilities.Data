
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

// ReSharper disable InconsistentNaming
namespace Jlw.Utilities.Data.DataTables
{
    /// <summary>
    /// Interface IDataTablesInputColumn
    /// </summary>
    public interface IDataTablesInputColumn
    {
        /// <summary>
        /// Gets or sets the data source for the column.
        /// </summary>
        /// <remarks>
        /// This property corresponds to the <c>data</c> property in the jQuery.DataTables API.
        /// It specifies the data source for the column, which can be a property name, an array index,
        /// or a function that returns the data for the column.
        /// </remarks>
        string data { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the column, which can be used to reference the column in the DataTables API.
        /// </summary>
        string name { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether the column can be ordered by the user.
        /// </summary>
        /// <value>
        /// <c>true</c> if the column is orderable; otherwise, <c>false</c>.
        /// </value>
        bool orderable { get; set; }
        
        /// <summary>
        /// Gets or sets the search criteria for the column.
        /// </summary>
        /// <value>
        /// An instance of <see cref="DataTablesInputSearch"/> representing the search parameters for the column.
        /// </value>
        DataTablesInputSearch Search { get; set; }
        bool searchable { get; set; }
    }
}
