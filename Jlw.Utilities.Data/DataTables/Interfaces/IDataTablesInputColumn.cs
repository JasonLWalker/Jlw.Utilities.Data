
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
    public interface IDataTablesInputColumn
    {
        string data { get; set; }
        string name { get; set; }
        bool orderable { get; set; }
        DataTablesInputSearch Search { get; set; }
        bool searchable { get; set; }
    }
}
