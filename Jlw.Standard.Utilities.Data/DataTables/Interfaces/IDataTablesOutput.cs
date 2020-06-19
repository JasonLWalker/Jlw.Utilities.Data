﻿using System.Collections.Generic;

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
    public interface IDataTablesOutput
    {
        int draw { get; set; }
        int recordsTotal { get; set; }

        int recordsFiltered { get; set; }
        IEnumerable<object> data { get; set; }
        string error { get; set; }

        string debug { get; set; }
    }
}