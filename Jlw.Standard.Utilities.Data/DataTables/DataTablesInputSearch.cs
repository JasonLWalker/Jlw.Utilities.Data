/****************************************************************************\
 *
 * Jlw.Standard.Utilities.Data.DataTables 
 * 
 * For use with the jQuery.DataTables v1.10 and higher. 
 * jQuery.DataTables v1.9 and earlier uses different member names and is not
 * compatible with this class.
 * 
 * Copyright 2013-2020 Jason L. Walker
 *
\****************************************************************************/

namespace Jlw.Standard.Utilities.Data.DataTables
{
    public class DataTablesInputSearch : IDataTablesInputSearch
    {
        public string value { get; set; }
        public bool regex { get; set; }

        public DataTablesInputSearch()
        {

        }

    }
}