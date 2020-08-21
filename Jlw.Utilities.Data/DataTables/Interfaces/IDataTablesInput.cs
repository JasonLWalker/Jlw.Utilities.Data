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
    public interface IDataTablesInput
    {
        // ReSharper disable once InconsistentNaming
        int draw { get; set; }

        // ReSharper disable once InconsistentNaming
        int length { get; set; }

        // ReSharper disable once InconsistentNaming
        IEnumerable<DataTablesInputOrder> order { get; set; }

        // ReSharper disable once InconsistentNaming
        DataTablesInputSearch search { get; set; }

        // ReSharper disable once InconsistentNaming
        IEnumerable<DataTablesInputColumn> columns { get; set; }

        // ReSharper disable once InconsistentNaming
        int start { get; set; }
    }
}