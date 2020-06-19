using System.Collections.Generic;

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
    public class DataTablesInput : IDataTablesInput
    {
        public int draw { get; set; }
        public int start { get; set; }

        public int length { get; set; }
        public DataTablesInputSearch search { get; set; }
        public IEnumerable<DataTablesInputOrder> order { get; set; }
        public IEnumerable<DataTablesInputColumn> columns { get; set; }

    }
}