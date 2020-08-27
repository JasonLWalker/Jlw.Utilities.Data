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
    public class DataTablesInputColumn : IDataTablesInputColumn
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public DataTablesInputSearch Search { get; set; }

        public DataTablesInputColumn()
        {

        }
    }
}