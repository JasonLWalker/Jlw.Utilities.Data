using System;

namespace Jlw.Utilities.Data.Tests
{
    [Flags]
    public enum FlaggedEnumeration
    {
        Default = 0,
        Unknown = 0,
        Bit1 = 1 << 0,
        Bit2 = 1 << 1,
        Bit3 = 1 << 2,
        Bit4 = 1 << 3,
        Bit5 = 1 << 4,
        Bit6 = 1 << 5,
        Bit7 = 1 << 6,
        Bit8 = 1 << 7,
        ByteMask = Bit1 | Bit2 | Bit3 | Bit4 | Bit5 | Bit6 | Bit7 | Bit8,
        LowNibble = Bit1 | Bit2 | Bit3 | Bit4,
        HighNibble = Bit5 | Bit6 | Bit7 | Bit8,
        ByteMask2 = 255
    }
}