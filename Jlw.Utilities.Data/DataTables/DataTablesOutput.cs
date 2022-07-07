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
    /// <inheritdoc />
    public class DataTablesOutput : IDataTablesOutput
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IEnumerable<object> data { get; set; }
        public string error { get; set; }

        public string debug { get; set; }
        internal IDataTablesInput Input;

        public DataTablesOutput()
        {
            Input = new DataTablesInput();
            Initialize();
        }

        public DataTablesOutput(IDataTablesInput input)
        {
            Input = input;
            Initialize();
        }

        internal void Initialize()
        {
            draw = Input?.draw ?? 0;
            data = new List<object>();
        }
    }
}