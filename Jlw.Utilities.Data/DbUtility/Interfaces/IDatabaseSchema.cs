using System;

namespace Jlw.Utilities.Data.DbUtility
{
    /// <summary>
    /// Interface IDatabaseSchema
    /// </summary>
    /// TODO Edit XML Comment Template for IDatabaseSchema
    public interface IDatabaseSchema
    {
        string Name { get; }
        string DefaultCollation { get; }
        DateTime CreationDate { get; }

    }
}
