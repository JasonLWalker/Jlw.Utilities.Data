using System;

namespace Jlw.Utilities.Data.DbUtility
{
    public interface IDatabaseSchema
    {
        string Name { get; }
        string DefaultCollation { get; }
        DateTime CreationDate { get; }

    }
}
