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
    public class DataTablesInputColumn : IDataTablesInputColumn
    {
        /// <inheritdoc />
        public string data { get; set; }
        /// <inheritdoc />
        public string name { get; set; }
        /// <inheritdoc />
        public bool searchable { get; set; }
        /// <inheritdoc />
        public bool orderable { get; set; }
        /// <inheritdoc />
        public DataTablesInputSearch Search { get; set; }

        /// <inheritdoc />
        public DataTablesInputColumn()
        {

        }
    }
}