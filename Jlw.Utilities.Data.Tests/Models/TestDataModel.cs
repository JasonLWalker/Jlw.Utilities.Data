using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Jlw.Utilities.Data.Tests
{
    public class TestDataModel : ITestDataModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdated { get; set; }

        public TestDataModel()
        {

        }

        public TestDataModel(IDataRecord o)
        {
            Id = DataUtility.ParseLong(o, "Id");
            Name = DataUtility.ParseString(o, "Name");
            Description = DataUtility.ParseString(o, "Description");
            LastUpdated = DataUtility.ParseDateTime(o, "LastUpdated");
        }
    }
}
