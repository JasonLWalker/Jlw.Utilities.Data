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
    /// Interface IDataTablesInputSearch
    /// </summary>
    public interface IDataTablesInputSearch
    {
        /// <summary>
        /// Gets or sets a value indicating whether the search term should be treated as a regular expression.
        /// </summary>
        /// <value>
        /// <c>true</c> if the search term should be treated as a regular expression; otherwise, <c>false</c>.
        /// </value>
        bool regex { get; set; }
        
        /// <summary>
        /// Gets or sets the search value to be applied to the data.
        /// </summary>
        /// <remarks>
        /// This property represents the search term used in conjunction with the jQuery.DataTables plugin
        /// to filter data. It works in combination with the <see cref="regex"/> property
        /// to determine whether the search should be treated as a regular expression.
        /// </remarks>
        string value { get; set; }
    }
}
