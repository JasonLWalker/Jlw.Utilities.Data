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
    public class DataTablesInputOrder : IDataTablesInputOrder
    {
        public int column { get; set; }
        public string dir { get; set; } = "ASC";

        public DataTablesInputOrder()
        {
        }
    }
}