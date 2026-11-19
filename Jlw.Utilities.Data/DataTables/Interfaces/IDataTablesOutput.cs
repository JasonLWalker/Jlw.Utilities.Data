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

// ReSharper disable InconsistentNaming
namespace Jlw.Utilities.Data.DataTables
{
    /// <summary>
    /// Interface IDataTablesOutput
    /// </summary>
    public interface IDataTablesOutput
    {
        /// <summary>
        /// Gets or sets the draw counter that this object is a response to.
        /// </summary>
        /// <remarks>
        /// This property corresponds to the `draw` parameter in the jQuery DataTables API.
        /// It is used to ensure that the response matches the request, helping to prevent
        /// issues with out-of-sequence responses in asynchronous environments.
        /// </remarks>
        int draw { get; set; }
        
        /// <summary>
        /// Gets or sets the total number of records available in the data source,
        /// irrespective of any filtering applied.
        /// </summary>
        /// <remarks>
        /// This property represents the total count of records before any filtering
        /// or pagination is applied. It is typically used to display the overall
        /// size of the dataset in conjunction with paginated results.
        /// </remarks>
        int recordsTotal { get; set; }

        /// <summary>
        /// Gets or sets the number of records that match the filtering criteria applied to the data set.
        /// </summary>
        /// <remarks>
        /// This property represents the total count of records after applying any search or filter conditions.
        /// It is used by jQuery.DataTables to display the filtered record count.
        /// </remarks>
        int recordsFiltered { get; set; }
        
        /// <summary>
        /// Gets or sets the collection of data objects to be returned in the DataTables response.
        /// </summary>
        /// <remarks>
        /// This property represents the data payload that will be sent back to the client-side 
        /// DataTables instance. It typically contains the rows of data to be displayed in the table.
        /// </remarks>
        IEnumerable<object> data { get; set; }
        
        /// <summary>
        /// Gets or sets an error message that provides additional information about an error
        /// encountered during the processing of a DataTables request.
        /// </summary>
        /// <remarks>
        /// This property is typically used to communicate error details to the client-side
        /// DataTables implementation when an issue occurs during server-side processing.
        /// </remarks>
        string error { get; set; }
        
        /// <summary>
        /// Gets or sets a debug message or information related to the DataTables operation.
        /// This property is typically used for debugging purposes and may contain
        /// SQL queries or other diagnostic details when debugging is enabled.
        /// </summary>

        string debug { get; set; }
    }
}