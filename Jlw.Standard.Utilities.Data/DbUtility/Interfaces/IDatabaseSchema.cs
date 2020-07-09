using System;

namespace Jlw.Standard.Utilities.Data.DbUtility
{
    public interface IDatabaseSchema
    {
        string Name { get; }
        string DefaultCollation { get; }
        DateTime CreationDate { get; }

    }
}
