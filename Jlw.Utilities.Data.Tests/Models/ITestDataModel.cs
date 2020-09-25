using System;

namespace Jlw.Utilities.Data.Tests
{
    public interface ITestDataModel
    {
        long Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        DateTime LastUpdated { get; set; }
    }
}