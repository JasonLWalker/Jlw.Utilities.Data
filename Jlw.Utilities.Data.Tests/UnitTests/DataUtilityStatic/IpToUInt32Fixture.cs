using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Utilities.Data.Tests.UnitTests.DataUtilityStatic
{
    [TestClass]
    public class IpToUInt32Fixture
    {

        [TestMethod]
        public void ShouldBeZeroForInvalidIp()
        {
            Assert.AreEqual((UInt32)0, DataUtility.IpToUInt32(null));
            Assert.AreEqual((UInt32)0, DataUtility.IpToUInt32(""));
            Assert.AreEqual((UInt32)0, DataUtility.IpToUInt32("abcdefg"));
            Assert.AreEqual((UInt32)0, DataUtility.IpToUInt32("255.255.255.255.255"));
            Assert.AreEqual((UInt32)0, DataUtility.IpToUInt32("This is a test!"));
            Assert.AreEqual((UInt32)0, DataUtility.IpToUInt32("a.b.c.d"));
        }


        [TestMethod]
        public void ShouldMatchForIp()
        {
            Assert.AreEqual((UInt32)0b00000000_00000000_00000000_00000000, DataUtility.IpToUInt32("0.0.0.0"));
            Assert.AreEqual((UInt32)0b10000000_00000000_00000000_00000000,DataUtility.IpToUInt32("128.0.0.0"));
            Assert.AreEqual((UInt32)0b11111111_00000000_00000000_00000000,DataUtility.IpToUInt32("255.0.0.0"));
            Assert.AreEqual((UInt32)0b11111111_10000000_00000000_00000000,DataUtility.IpToUInt32("255.128.0.0"));
            Assert.AreEqual((UInt32)0b11111111_11111111_00000000_00000000,DataUtility.IpToUInt32("255.255.0.0"));
            Assert.AreEqual((UInt32)0b11111111_11111111_10000000_00000000,DataUtility.IpToUInt32("255.255.128.0"));
            Assert.AreEqual((UInt32)0b11111111_11111111_11111111_00000000,DataUtility.IpToUInt32("255.255.255.0"));
            Assert.AreEqual((UInt32)0b11111111_11111111_11111111_10000000,DataUtility.IpToUInt32("255.255.255.128"));
            Assert.AreEqual((UInt32)0b11111111_11111111_11111111_11111111,DataUtility.IpToUInt32("255.255.255.255"));

            Assert.AreEqual((UInt32)0b00001010_00010111_00000010_01100100,DataUtility.IpToUInt32("10.23.2.100"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000,DataUtility.IpToUInt32("204.184.214.32"));
            Assert.AreEqual((UInt32)0b11000000_10101000_00000000_00000001,DataUtility.IpToUInt32("192.168.0.1"));

        }


        [TestMethod]
        public void ShouldBeZeroForIpWithInvalidMask()
        {
            Assert.AreEqual((UInt32)0, DataUtility.IpToUInt32("255.255.255.255/a"));
            Assert.AreEqual((UInt32)0, DataUtility.IpToUInt32("255.255.255.255/-10"));
            Assert.AreEqual((UInt32)0, DataUtility.IpToUInt32("255.255.255.255/33"));
            Assert.AreEqual((UInt32)0, DataUtility.IpToUInt32("204.184.214.32/321"));
        }

        [TestMethod]
        public void ShouldMatchForMaskedIp()
        {
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/0"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/1"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/2"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/3"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/4"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/5"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/6"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/7"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/8"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/9"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/10"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/11"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/12"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/13"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/14"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/15"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/16"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/17"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/18"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/19"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/20"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/21"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/22"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/23"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/24"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/25"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/26"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/27"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/28"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/29"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/30"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/31"));
            Assert.AreEqual((UInt32)0b11001100_10111000_11010110_00100000, DataUtility.IpToUInt32("204.184.214.32/32"));
        }

    }
}
