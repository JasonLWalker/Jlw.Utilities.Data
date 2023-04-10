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
    /// <summary>
    /// Interface IDataTablesBase
    /// </summary>
    /// TODO Edit XML Comment Template for IDataTablesBase
    public interface IDataTablesBase
    {
        int CommandTimeout { get; set; }

        IEnumerable<object> Data { get; }

        void AddColumn(string columnName, string sqlFragment = null);
        void AddExtraParams(string columnName, string sqlFragment);
        void AddSearchColumns(string columnName, string sqlFragment = null);
        void AddSortColumns(string columnName, string sqlFragment = null);
        IDataTablesOutput FetchData(string connString, string tables);
        void SetDebug(bool b);
        void SetGlobalFilter(string sqlFragment);
    }
}