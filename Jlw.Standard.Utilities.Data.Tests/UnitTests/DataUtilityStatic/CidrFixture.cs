using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class CidrFixture
    {
        [TestMethod]
        // Double checked values via http://www.ip-tools.net/ipcalc
        [DataRow("10.23.2.101/16", "10.23.2.101", 16, "10.23.0.0", "10.23.0.1", "10.23.255.254", "10.23.255.255", (UInt32)65534)]
        [DataRow("192.168.2.100/24", "192.168.2.100", 24, "192.168.2.0", "192.168.2.1", "192.168.2.254", "192.168.2.255", (UInt32)254)]
        [DataRow("204.184.214.32/5", "204.184.214.32", 5, "200.0.0.0", "200.0.0.1", "207.255.255.254", "207.255.255.255", (UInt32)134217726)]
        [DataRow("8.8.8.8/30", "8.8.8.8", 30, "8.8.8.8", "8.8.8.9", "8.8.8.10", "8.8.8.11", (UInt32)2)]
        [DataRow("127.100.50.25/31", "127.100.50.25", 31, "127.100.50.24", "127.100.50.24", "127.100.50.25", "127.100.50.25", (UInt32)2)]
        [DataRow("204.184.214.31/32", "204.184.214.31", 32, "204.184.214.31", "204.184.214.31", "204.184.214.31", "204.184.214.31", (UInt32)1)]
        [DataRow("127.2.1.38/8", "127.2.1.38", 8, "127.0.0.0", "127.0.0.1", "127.255.255.254", "127.255.255.255", (UInt32)16777214)]
        [DataRow("182.184.214.32/2", "182.184.214.32", 2, "128.0.0.0", "128.0.0.1", "191.255.255.254", "191.255.255.255", (UInt32)1073741822)]
        [DataRow("182.184.214.33/1", "182.184.214.33", 1, "128.0.0.0", "128.0.0.1", "255.255.255.254", "255.255.255.255", (UInt32)2147483646)]
        [DataRow("127.184.214.33/1", "127.184.214.33", 1, "0.0.0.0", "0.0.0.1", "127.255.255.254", "127.255.255.255", (UInt32)2147483646)]
        [DataRow("254.184.214.32/0", "254.184.214.32", 0, "0.0.0.0", "0.0.0.1", "255.255.255.254", "255.255.255.255", (UInt32)4294967295)]
        public void Should_Match_ForValidMaskedIp(string cidr, string address, int mask, string net, string firstHost, string lastHost, string broadcast, UInt32 hosts)
        {
            TestCidrObject(new DataUtility.CIDR(cidr), address, mask, net, firstHost, lastHost, broadcast, hosts);
        }

        public void TestCidrObject(DataUtility.CIDR cidr, string address, int mask, string net, string firstHost, string lastHost, string broadcast, UInt32 hosts)
        {
            Assert.AreEqual(address, cidr.Address, $"Address does not match for {cidr.Address}/{cidr.Mask}.");
            Assert.AreEqual(DataUtility.UInt32ToIp(DataUtility.ParseCidrMask(mask)), cidr.NetMask, $"Net Mask does not match for {cidr.Address}/{cidr.Mask}.");
            Assert.AreEqual(~DataUtility.ParseCidrMask(mask), cidr.NetMaskInverse, $"Inverse Net Mask does not match for {cidr.Address}/{cidr.Mask}");
            Assert.AreEqual(net, cidr.Net, $"Net does not match for {cidr.Address}/{cidr.Mask}");
            Assert.AreEqual(hosts, cidr.Hosts, $"Number of hosts does not match for {cidr.Address}/{cidr.Mask}.");

            Assert.AreEqual(firstHost, cidr.FirstHost, $"First Host does not match for {cidr.Address}/{cidr.Mask}.");
            Assert.AreEqual(lastHost, cidr.LastHost, $"Last Host does not match for {cidr.Address}/{cidr.Mask}.");
            Assert.AreEqual(broadcast, cidr.Broadcast, $"Broadcast address does not match for {cidr.Address}/{cidr.Mask}.");
            Assert.AreEqual(mask, cidr.Mask, $"Bit Mask does not match for {cidr.Address}/{cidr.Mask}.");
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("abcdefg")]
        [DataRow("255.255.255.255.255")]
        [DataRow("255.255.255.255")]
        [DataRow("This is a test!")]
        [DataRow("a.b.c.d")]
        public void Should_BeZero_ForInvalidIpMask(string ip)
        {
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask(ip));
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(33)]
        [DataRow(256)]
        [DataRow(-24)]
        [DataRow(100)]
        public void Should_BeZero_ForInvalidBitRange(int bit)
        {
            // Bit range must be between 0-31
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask(bit));
        }

        [TestMethod]
        [DataRow((UInt32)0b0000_0000_0000_0000_0000_0000_0000_0000, 0)]
        [DataRow((UInt32)0b1000_0000_0000_0000_0000_0000_0000_0000, 1)]
        [DataRow((UInt32)0b1100_0000_0000_0000_0000_0000_0000_0000, 2)]
        [DataRow((UInt32)0b1110_0000_0000_0000_0000_0000_0000_0000, 3)]
        [DataRow((UInt32)0b1111_0000_0000_0000_0000_0000_0000_0000, 4)]
        [DataRow((UInt32)0b1111_1000_0000_0000_0000_0000_0000_0000, 5)]
        [DataRow((UInt32)0b1111_1100_0000_0000_0000_0000_0000_0000, 6)]
        [DataRow((UInt32)0b1111_1110_0000_0000_0000_0000_0000_0000, 7)]
        [DataRow((UInt32)0b1111_1111_0000_0000_0000_0000_0000_0000, 8)]
        [DataRow((UInt32)0b1111_1111_1000_0000_0000_0000_0000_0000, 9)]
        [DataRow((UInt32)0b1111_1111_1100_0000_0000_0000_0000_0000, 10)]
        [DataRow((UInt32)0b1111_1111_1110_0000_0000_0000_0000_0000, 11)]
        [DataRow((UInt32)0b1111_1111_1111_0000_0000_0000_0000_0000, 12)]
        [DataRow((UInt32)0b1111_1111_1111_1000_0000_0000_0000_0000, 13)]
        [DataRow((UInt32)0b1111_1111_1111_1100_0000_0000_0000_0000, 14)]
        [DataRow((UInt32)0b1111_1111_1111_1110_0000_0000_0000_0000, 15)]
        [DataRow((UInt32)0b1111_1111_1111_1111_0000_0000_0000_0000, 16)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1000_0000_0000_0000, 17)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1100_0000_0000_0000, 18)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1110_0000_0000_0000, 19)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_0000_0000_0000, 20)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1000_0000_0000, 21)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1100_0000_0000, 22)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1110_0000_0000, 23)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_0000_0000, 24)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1000_0000, 25)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1100_0000, 26)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1110_0000, 27)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1111_0000, 28)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1000, 29)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1100, 30)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1110, 31)]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1111, 32)]
        public void Should_Match_ForBit(UInt32 expected, int bit)
        {
            Assert.AreEqual(expected, DataUtility.ParseCidrMask(bit));
        }

        [TestMethod]
        [DataRow("255.255.255.255/a")]
        [DataRow("255.255.255.255/-10")]
        [DataRow("255.255.255.255/33")]
        [DataRow("204.184.214.32/321")]
        public void Should_BeZero_ForIpWithInvalidMask(string ip)
        {
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask(ip));
        }

        [TestMethod]
        [DataRow((UInt32)0b0000_0000_0000_0000_0000_0000_0000_0000, "000.184.214.254/0")]
        [DataRow((UInt32)0b1000_0000_0000_0000_0000_0000_0000_0000, "204.000.214.254/1")]
        [DataRow((UInt32)0b1100_0000_0000_0000_0000_0000_0000_0000, "204.184.000.254/2")]
        [DataRow((UInt32)0b1110_0000_0000_0000_0000_0000_0000_0000, "204.184.214.000/3")]
        [DataRow((UInt32)0b1110_0000_0000_0000_0000_0000_0000_0000, "001.184.214.254/3")]
        [DataRow((UInt32)0b1110_0000_0000_0000_0000_0000_0000_0000, "204.002.214.254/3")]
        [DataRow((UInt32)0b1110_0000_0000_0000_0000_0000_0000_0000, "204.184.003.254/3")]
        [DataRow((UInt32)0b1110_0000_0000_0000_0000_0000_0000_0000, "204.184.214.004/3")]
        [DataRow((UInt32)0b1111_0000_0000_0000_0000_0000_0000_0000, "00.184.214.254/4")]
        [DataRow((UInt32)0b1111_1000_0000_0000_0000_0000_0000_0000, "204.00.214.254/5")]
        [DataRow((UInt32)0b1111_1100_0000_0000_0000_0000_0000_0000, "204.184.00.254/6")]
        [DataRow((UInt32)0b1111_1110_0000_0000_0000_0000_0000_0000, "204.184.214.00/7")]
        [DataRow((UInt32)0b1111_1111_0000_0000_0000_0000_0000_0000, "01.184.214.32/8")]
        [DataRow((UInt32)0b1111_1111_1000_0000_0000_0000_0000_0000, "204.02.214.32/9")]
        [DataRow((UInt32)0b1111_1111_1000_0000_0000_0000_0000_0000, "204.184.03.32/9")]
        [DataRow((UInt32)0b1111_1111_1000_0000_0000_0000_0000_0000, "204.184.214.04/9")]
        [DataRow((UInt32)0b0000_0000_0000_0000_0000_0000_0000_0000, "0.184.214.254/00")]
        [DataRow((UInt32)0b1000_0000_0000_0000_0000_0000_0000_0000, "204.1.214.254/01")]
        [DataRow((UInt32)0b1100_0000_0000_0000_0000_0000_0000_0000, "204.184.2.254/02")]
        [DataRow((UInt32)0b1110_0000_0000_0000_0000_0000_0000_0000, "204.184.214.3/03")]
        [DataRow((UInt32)0b1111_0000_0000_0000_0000_0000_0000_0000, "4.184.214.254/04")]
        [DataRow((UInt32)0b1111_1000_0000_0000_0000_0000_0000_0000, "204.5.214.254/05")]
        [DataRow((UInt32)0b1111_1100_0000_0000_0000_0000_0000_0000, "204.184.6.254/06")]
        [DataRow((UInt32)0b1111_1110_0000_0000_0000_0000_0000_0000, "204.184.214.7/07")]
        [DataRow((UInt32)0b1111_1111_0000_0000_0000_0000_0000_0000, "8.184.214.254/08")]
        [DataRow((UInt32)0b1111_1111_1000_0000_0000_0000_0000_0000, "204.9.214.254/09")]
        [DataRow((UInt32)0b1111_1111_1100_0000_0000_0000_0000_0000, "204.184.10.254/10")]
        [DataRow((UInt32)0b1111_1111_1110_0000_0000_0000_0000_0000, "204.184.214.11/11")]
        [DataRow((UInt32)0b1111_1111_1111_0000_0000_0000_0000_0000, "12.184.214.32/12")]
        [DataRow((UInt32)0b1111_1111_1111_1000_0000_0000_0000_0000, "204.13.214.32/13")]
        [DataRow((UInt32)0b1111_1111_1111_1100_0000_0000_0000_0000, "204.184.14.32/14")]
        [DataRow((UInt32)0b1111_1111_1111_1110_0000_0000_0000_0000, "204.184.214.15/15")]
        [DataRow((UInt32)0b1111_1111_1111_1111_0000_0000_0000_0000, "16.184.214.32/16")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1000_0000_0000_0000, "204.17.214.32/17")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1100_0000_0000_0000, "204.184.18.32/18")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1110_0000_0000_0000, "204.184.214.19/19")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_0000_0000_0000, "20.184.214.32/20")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1000_0000_0000, "204.21.214.32/21")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1100_0000_0000, "204.184.22.32/22")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1110_0000_0000, "204.184.214.23/23")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_0000_0000, "24.184.214.32/24")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1000_0000, "204.25.214.32/25")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1100_0000, "204.184.26.32/26")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1110_0000, "204.184.214.27/27")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1111_0000, "28.184.214.32/28")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1000, "204.29.214.32/29")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1100, "204.184.30.32/30")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1110, "204.184.214.31/31")]
        [DataRow((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1111, "32.184.214.32/32")]
        public void Should_Match_ForMaskedIp(UInt32 expected, string ip)
        {
            Assert.AreEqual(expected, DataUtility.ParseCidrMask(ip));
        }
    }
}
