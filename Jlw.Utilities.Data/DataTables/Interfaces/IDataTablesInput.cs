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
    /// Interface IDataTablesInput
    /// </summary>
    public interface IDataTablesInput
    {
        /// <summary>
        /// Gets or sets the draw counter that this object is a response to.
        /// </summary>
        /// <remarks>
        /// This property is used by DataTables to ensure that the Ajax responses from the server 
        /// are drawn in sequence by DataTables (Ajax requests are asynchronous and thus can return 
        /// out of sequence). This is simply a copy of the `draw` parameter sent by DataTables.
        /// </remarks>
        // ReSharper disable once InconsistentNaming
        int draw { get; set; }

        /// <summary>
        /// Gets or sets the number of records to return in the paginated result set.
        /// </summary>
        /// <remarks>
        /// This property is used to specify the page size for paginated data retrieval.
        /// A value of <c>0</c> or less may indicate that no pagination is applied.
        /// </remarks>
        // ReSharper disable once InconsistentNaming
        int length { get; set; }

        /// <summary>
        /// Gets or sets the collection of order definitions for sorting columns in the DataTables request.
        /// </summary>
        /// <remarks>
        /// Each order definition specifies the column index and the sorting direction (e.g., ascending or descending).
        /// </remarks>
        // ReSharper disable once InconsistentNaming
        IEnumerable<DataTablesInputOrder> order { get; set; }

        /// <summary>
        /// Gets or sets the search criteria used for filtering data in the DataTables input.
        /// </summary>
        /// <remarks>
        /// This property represents the global search criteria, which includes the search value and
        /// an indicator of whether the search should be treated as a regular expression.
        /// </remarks>
        // ReSharper disable once InconsistentNaming
        DataTablesInputSearch search { get; set; }

        /// <summary>
        /// Gets or sets the collection of columns provided as input for the DataTables request.
        /// </summary>
        /// <value>
        /// A collection of <see cref="DataTablesInputColumn"/> objects representing the columns
        /// in the DataTables request. Each column contains metadata such as its name, data binding,
        /// and search or orderability options.
        /// </value>
        // ReSharper disable once InconsistentNaming
        IEnumerable<DataTablesInputColumn> columns { get; set; }

        /// <summary>
        /// Gets or sets the starting index of the data to be retrieved.
        /// </summary>
        /// <remarks>
        /// This property is typically used for pagination purposes, representing the zero-based index 
        /// of the first record to be included in the current page of data.
        /// </remarks>
        // ReSharper disable once InconsistentNaming
        int start { get; set; }
    }
}