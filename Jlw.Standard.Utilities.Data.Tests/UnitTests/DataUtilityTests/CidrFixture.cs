﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests
{
    [TestClass]
    public class CidrFixture
    {

        [TestMethod]
        public void ShouldMatchForValidMaskedIp()
        {
            // Double checked values via http://www.ip-tools.net/ipcalc

            TestCidrObject(new DataUtility.CIDR("10.23.2.101/16"), "10.23.2.101", 16, "10.23.0.0", "10.23.0.1", "10.23.255.254", "10.23.255.255", 65534 );
            TestCidrObject(new DataUtility.CIDR("192.168.2.100/24"), "192.168.2.100", 24, "192.168.2.0", "192.168.2.1", "192.168.2.254", "192.168.2.255", 254);
            TestCidrObject(new DataUtility.CIDR("204.184.214.32/5"), "204.184.214.32", 5, "200.0.0.0", "200.0.0.1", "207.255.255.254", "207.255.255.255", 134217726);
            TestCidrObject(new DataUtility.CIDR("8.8.8.8/30"), "8.8.8.8", 30, "8.8.8.8", "8.8.8.9", "8.8.8.10", "8.8.8.11", 2);
            TestCidrObject(new DataUtility.CIDR("127.100.50.25/31"), "127.100.50.25", 31, "127.100.50.24", "127.100.50.24", "127.100.50.25", "127.100.50.25", 2);
            TestCidrObject(new DataUtility.CIDR("204.184.214.31/32"), "204.184.214.31", 32, "204.184.214.31", "204.184.214.31", "204.184.214.31", "204.184.214.31", 1);
            TestCidrObject(new DataUtility.CIDR("127.2.1.38/8"), "127.2.1.38", 8, "127.0.0.0", "127.0.0.1", "127.255.255.254", "127.255.255.255", 16777214);
            TestCidrObject(new DataUtility.CIDR("182.184.214.32/2"), "182.184.214.32", 2, "128.0.0.0", "128.0.0.1", "191.255.255.254", "191.255.255.255", 1073741822);
            TestCidrObject(new DataUtility.CIDR("182.184.214.33/1"), "182.184.214.33", 1, "128.0.0.0", "128.0.0.1", "255.255.255.254", "255.255.255.255", 2147483646);
            TestCidrObject(new DataUtility.CIDR("127.184.214.33/1"), "127.184.214.33", 1, "0.0.0.0", "0.0.0.1", "127.255.255.254", "127.255.255.255", 2147483646);
            TestCidrObject(new DataUtility.CIDR("254.184.214.32/0"), "254.184.214.32", 0, "0.0.0.0", "0.0.0.1", "255.255.255.254", "255.255.255.255", 4294967295);
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

        /*
        [TestMethod]
        public void ShouldBeZeroForInvalidIpMask()
        {
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask(null));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask(""));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask("abcdefg"));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask("255.255.255.255.255"));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask("255.255.255.255"));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask("This is a test!"));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask("a.b.c.d"));
        }

        [TestMethod]
        public void ShouldBeZeroForInvalidUInt32()
        {
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask(-1));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask(33));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask(256));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask(255));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask(-24));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask(100));
        }

        [TestMethod]
        public void ShouldMatchForUInt32()
        {
            Assert.AreEqual((UInt32)0b0000_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(0));
            Assert.AreEqual((UInt32)0b1000_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(1));
            Assert.AreEqual((UInt32)0b1100_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(2));
            Assert.AreEqual((UInt32)0b1110_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(3));
            Assert.AreEqual((UInt32)0b1111_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(4));
            Assert.AreEqual((UInt32)0b1111_1000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(5));
            Assert.AreEqual((UInt32)0b1111_1100_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(6));
            Assert.AreEqual((UInt32)0b1111_1110_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(7));
            Assert.AreEqual((UInt32)0b1111_1111_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(8));
            Assert.AreEqual((UInt32)0b1111_1111_1000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(9));
            Assert.AreEqual((UInt32)0b1111_1111_1100_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(10));
            Assert.AreEqual((UInt32)0b1111_1111_1110_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(11));
            Assert.AreEqual((UInt32)0b1111_1111_1111_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask(12));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1000_0000_0000_0000_0000, DataUtility.ParseCidrMask(13));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1100_0000_0000_0000_0000, DataUtility.ParseCidrMask(14));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1110_0000_0000_0000_0000, DataUtility.ParseCidrMask(15));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_0000_0000_0000_0000, DataUtility.ParseCidrMask(16));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1000_0000_0000_0000, DataUtility.ParseCidrMask(17));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1100_0000_0000_0000, DataUtility.ParseCidrMask(18));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1110_0000_0000_0000, DataUtility.ParseCidrMask(19));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_0000_0000_0000, DataUtility.ParseCidrMask(20));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1000_0000_0000, DataUtility.ParseCidrMask(21));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1100_0000_0000, DataUtility.ParseCidrMask(22));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1110_0000_0000, DataUtility.ParseCidrMask(23));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_0000_0000, DataUtility.ParseCidrMask(24));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1000_0000, DataUtility.ParseCidrMask(25));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1100_0000, DataUtility.ParseCidrMask(26));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1110_0000, DataUtility.ParseCidrMask(27));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1111_0000, DataUtility.ParseCidrMask(28));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1000, DataUtility.ParseCidrMask(29));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1100, DataUtility.ParseCidrMask(30));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1110, DataUtility.ParseCidrMask(31));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1111, DataUtility.ParseCidrMask(32));
        }


        [TestMethod]
        public void ShouldBeZeroForIpWithInvalidMask()
        {
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask("255.255.255.255/a"));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask("255.255.255.255/-10"));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask("255.255.255.255/33"));
            Assert.AreEqual((UInt32)0, DataUtility.ParseCidrMask("204.184.214.32/321"));
        }

        [TestMethod]
        public void ShouldMatchForMaskedIp()
        {
            Assert.AreEqual((UInt32)0b0000_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/0"));
            Assert.AreEqual((UInt32)0b1000_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/1"));
            Assert.AreEqual((UInt32)0b1100_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/2"));
            Assert.AreEqual((UInt32)0b1110_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/3"));
            Assert.AreEqual((UInt32)0b1111_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/4"));
            Assert.AreEqual((UInt32)0b1111_1000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/5"));
            Assert.AreEqual((UInt32)0b1111_1100_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/6"));
            Assert.AreEqual((UInt32)0b1111_1110_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/7"));
            Assert.AreEqual((UInt32)0b1111_1111_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/8"));
            Assert.AreEqual((UInt32)0b1111_1111_1000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/9"));
            Assert.AreEqual((UInt32)0b0000_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/00"));
            Assert.AreEqual((UInt32)0b1000_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/01"));
            Assert.AreEqual((UInt32)0b1100_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/02"));
            Assert.AreEqual((UInt32)0b1110_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/03"));
            Assert.AreEqual((UInt32)0b1111_0000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/04"));
            Assert.AreEqual((UInt32)0b1111_1000_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/05"));
            Assert.AreEqual((UInt32)0b1111_1100_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/06"));
            Assert.AreEqual((UInt32)0b1111_1110_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/07"));
            Assert.AreEqual((UInt32)0b1111_1111_0000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/08"));
            Assert.AreEqual((UInt32)0b1111_1111_1000_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/09"));
            Assert.AreEqual((UInt32)0b1111_1111_1100_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/10"));
            Assert.AreEqual((UInt32)0b1111_1111_1110_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/11"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_0000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/12"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1000_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/13"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1100_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/14"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1110_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/15"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_0000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/16"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1000_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/17"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1100_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/18"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1110_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/19"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_0000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/20"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1000_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/21"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1100_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/22"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1110_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/23"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_0000_0000, DataUtility.ParseCidrMask("204.184.214.32/24"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1000_0000, DataUtility.ParseCidrMask("204.184.214.32/25"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1100_0000, DataUtility.ParseCidrMask("204.184.214.32/26"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1110_0000, DataUtility.ParseCidrMask("204.184.214.32/27"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1111_0000, DataUtility.ParseCidrMask("204.184.214.32/28"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1000, DataUtility.ParseCidrMask("204.184.214.32/29"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1100, DataUtility.ParseCidrMask("204.184.214.32/30"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1110, DataUtility.ParseCidrMask("204.184.214.32/31"));
            Assert.AreEqual((UInt32)0b1111_1111_1111_1111_1111_1111_1111_1111, DataUtility.ParseCidrMask("204.184.214.32/32"));
        }
        */


    }
}
