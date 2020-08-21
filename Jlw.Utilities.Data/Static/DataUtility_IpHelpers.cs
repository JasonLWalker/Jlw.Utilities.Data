
// ReSharper disable once CheckNamespace

using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Jlw.Utilities.Data
{
    public partial class DataUtility
    {
        private static Regex _rxIp = new Regex(@"^([0-9]{1,3})\.([0-9]{1,3})\.([0-9]{1,3})\.([0-9]{1,3})\/?([0-2][0-9]|3[0-2]|[0-9])?$");

        public class CIDR
        {
            private uint _address;
            private uint _netmask;
            private int _mask;
            public string Address => DataUtility.UInt32ToIp(_address);

            public UInt32 AddressVal
            {
                get => _address;
                protected set => _address = value;
            }

            public string NetMask => DataUtility.UInt32ToIp(_netmask);
            public UInt32 NetMaskVal => _netmask;
            public UInt32 NetMaskInverse => ~_netmask;

            public string Net => DataUtility.UInt32ToIp( NetVal);
            public UInt32 NetVal => _address & _netmask;

            public string FirstHost => DataUtility.UInt32ToIp(FirstHostVal);
            public UInt32 FirstHostVal => BroadcastVal - (NetMaskInverse <= 1 || _mask == 0 ? Hosts - 1: Hosts);
            public string LastHost => DataUtility.UInt32ToIp( LastHostVal );
            public UInt32 LastHostVal => BroadcastVal - (UInt32)(NetMaskInverse <= 2 ? 0 : 1);
            public string Broadcast => DataUtility.UInt32ToIp( BroadcastVal );
            public UInt32 BroadcastVal => (_address & _netmask) | NetMaskInverse;

            public int Mask => _mask;

            public UInt32 Hosts => (UInt32)(NetMaskInverse <= 2 ? NetMaskInverse + 1 : NetMaskInverse - (_mask == 0 ? 0: 1));

            public CIDR(string ip)
            {
                _address = DataUtility.IpToUInt32(ip);

                var matches = _rxIp.Match(ip);
                if (matches.Success && matches.Groups.Count > 4)
                {
                    _netmask = DataUtility.ParseCidrMask(_mask = DataUtility.ParseInt(matches.Groups[5].Value));
                }
            }

        }

        public static UInt32 IpToUInt32(string ip)
        {
            UInt32 addr = 0;
            if (string.IsNullOrWhiteSpace(ip))
                return 0;

            var matches = _rxIp.Match(ip);
            if (matches.Success && matches.Groups.Count >= 4)
            {
                addr |= ((UInt32)DataUtility.ParseInt(matches.Groups[1].Value) << 24);
                addr |= ((UInt32)DataUtility.ParseInt(matches.Groups[2].Value) << 16);
                addr |= ((UInt32)DataUtility.ParseInt(matches.Groups[3].Value) << 8);
                addr |= ((UInt32)DataUtility.ParseInt(matches.Groups[4].Value));
            }

            return addr;
        }

        public static string UInt32ToIp(UInt32 ip)
        {
            return $"{(ip & 0xFF000000) >> 24}.{(ip & 0x00FF0000) >> 16}.{(ip & 0x0000FF00) >> 8}.{ip & 0x000000FF}";
        }


        public static UInt32 ParseCidrMask(int mask)
        {
            switch(mask)
            {
                case 1:
                    return 0b1000_0000_0000_0000_0000_0000_0000_0000;
                case 2:
                    return 0b1100_0000_0000_0000_0000_0000_0000_0000;
                case 3:
                    return 0b1110_0000_0000_0000_0000_0000_0000_0000;
                case 4:
                    return 0b1111_0000_0000_0000_0000_0000_0000_0000;
                case 5:
                    return 0b1111_1000_0000_0000_0000_0000_0000_0000;
                case 6:
                    return 0b1111_1100_0000_0000_0000_0000_0000_0000;
                case 7:
                    return 0b1111_1110_0000_0000_0000_0000_0000_0000;
                case 8:
                    return 0b1111_1111_0000_0000_0000_0000_0000_0000;
                case 9:
                    return 0b1111_1111_1000_0000_0000_0000_0000_0000;
                case 10:
                    return 0b1111_1111_1100_0000_0000_0000_0000_0000;
                case 11:
                    return 0b1111_1111_1110_0000_0000_0000_0000_0000;
                case 12:
                    return 0b1111_1111_1111_0000_0000_0000_0000_0000;
                case 13:
                    return 0b1111_1111_1111_1000_0000_0000_0000_0000;
                case 14:
                    return 0b1111_1111_1111_1100_0000_0000_0000_0000;
                case 15:
                    return 0b1111_1111_1111_1110_0000_0000_0000_0000;
                case 16:
                    return 0b1111_1111_1111_1111_0000_0000_0000_0000;
                case 17:
                    return 0b1111_1111_1111_1111_1000_0000_0000_0000;
                case 18:
                    return 0b1111_1111_1111_1111_1100_0000_0000_0000;
                case 19:
                    return 0b1111_1111_1111_1111_1110_0000_0000_0000;
                case 20:
                    return 0b1111_1111_1111_1111_1111_0000_0000_0000;
                case 21:
                    return 0b1111_1111_1111_1111_1111_1000_0000_0000;
                case 22:
                    return 0b1111_1111_1111_1111_1111_1100_0000_0000;
                case 23:
                    return 0b1111_1111_1111_1111_1111_1110_0000_0000;
                case 24:
                    return 0b1111_1111_1111_1111_1111_1111_0000_0000;
                case 25:
                    return 0b1111_1111_1111_1111_1111_1111_1000_0000;
                case 26:
                    return 0b1111_1111_1111_1111_1111_1111_1100_0000;
                case 27:
                    return 0b1111_1111_1111_1111_1111_1111_1110_0000;
                case 28:
                    return 0b1111_1111_1111_1111_1111_1111_1111_0000;
                case 29:
                    return 0b1111_1111_1111_1111_1111_1111_1111_1000;
                case 30:
                    return 0b1111_1111_1111_1111_1111_1111_1111_1100;
                case 31:
                    return 0b1111_1111_1111_1111_1111_1111_1111_1110;
                case 32:
                    return 0b1111_1111_1111_1111_1111_1111_1111_1111;
            }

            return 0;
        }

        public static UInt32 ParseCidrMask(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
                return 0;

            var matches = _rxIp.Match(ip);
            if (matches.Success && matches.Groups.Count > 4)
            {
                return DataUtility.ParseCidrMask(DataUtility.ParseInt(matches.Groups[5].Value));
            }

            return 0;
        }
    }
}
