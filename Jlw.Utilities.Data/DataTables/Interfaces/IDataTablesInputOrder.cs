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
    /// Interface IDataTablesInputOrder
    /// </summary>
    public interface IDataTablesInputOrder
    {
        /// <summary>
        /// Gets or sets the column index to which the ordering should be applied.
        /// </summary>
        /// <remarks>
        /// This property corresponds to the zero-based index of the column in the data source.
        /// </remarks>
        int column { get; set; }
        
        /// <summary>
        /// Gets or sets the sort direction for the column.
        /// </summary>
        /// <remarks>
        /// The value is typically "ASC" for ascending or "DESC" for descending.
        /// </remarks>
        string dir { get; set; }
    }
}