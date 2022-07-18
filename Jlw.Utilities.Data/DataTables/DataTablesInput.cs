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
    /// <inheritdoc />
    public class DataTablesInput : IDataTablesInput
    {
        /// <inheritdoc />
        public int draw { get; set; }
        /// <inheritdoc />
        public int start { get; set; }

        /// <inheritdoc />
        public int length { get; set; }
        /// <inheritdoc />
        public DataTablesInputSearch search { get; set; }
        /// <inheritdoc />
        public IEnumerable<DataTablesInputOrder> order { get; set; }
        /// <inheritdoc />
        public IEnumerable<DataTablesInputColumn> columns { get; set; }

    }
}