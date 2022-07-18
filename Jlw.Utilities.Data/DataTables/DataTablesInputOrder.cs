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
    /// <inheritdoc />
    public class DataTablesInputOrder : IDataTablesInputOrder
    {
        /// <inheritdoc />
        public int column { get; set; }
        /// <inheritdoc />
        public string dir { get; set; } = "ASC";

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTablesInputOrder"/> class.
        /// </summary>
        public DataTablesInputOrder()
        {
        }
    }
}