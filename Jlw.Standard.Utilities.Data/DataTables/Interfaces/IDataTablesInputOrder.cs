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

// ReSharper disable InconsistentNaming
namespace Jlw.Standard.Utilities.Data.DataTables
{
    public interface IDataTablesInputOrder
    {
        int column { get; set; }
        string dir { get; set; }
    }
}