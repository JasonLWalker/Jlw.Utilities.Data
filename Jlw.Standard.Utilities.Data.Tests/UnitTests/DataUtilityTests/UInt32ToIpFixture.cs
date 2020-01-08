using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jlw.Standard.Utilities.Data.Tests.UnitTests
{
    [TestClass]
    public class UInt32ToIpFixture
    {

        [TestMethod]
        public void ShouldMatchForObject()
        {
            Assert.AreEqual("0.0.0.0",         DataUtility.UInt32ToIp(0b00000000_00000000_00000000_00000000));
            Assert.AreEqual("128.0.0.0",       DataUtility.UInt32ToIp(0b10000000_00000000_00000000_00000000));
            Assert.AreEqual("255.0.0.0",       DataUtility.UInt32ToIp(0b11111111_00000000_00000000_00000000));
            Assert.AreEqual("255.128.0.0",     DataUtility.UInt32ToIp(0b11111111_10000000_00000000_00000000));
            Assert.AreEqual("255.255.0.0",     DataUtility.UInt32ToIp(0b11111111_11111111_00000000_00000000));
            Assert.AreEqual("255.255.128.0",   DataUtility.UInt32ToIp(0b11111111_11111111_10000000_00000000));
            Assert.AreEqual("255.255.255.0",   DataUtility.UInt32ToIp(0b11111111_11111111_11111111_00000000));
            Assert.AreEqual("255.255.255.128", DataUtility.UInt32ToIp(0b11111111_11111111_11111111_10000000));
            Assert.AreEqual("255.255.255.255", DataUtility.UInt32ToIp(0b11111111_11111111_11111111_11111111));

            Assert.AreEqual("10.23.2.100", DataUtility.UInt32ToIp(0b00001010_00010111_00000010_01100100));
            Assert.AreEqual("204.184.214.32", DataUtility.UInt32ToIp(0b11001100_10111000_11010110_00100000));
            Assert.AreEqual("192.168.0.1", DataUtility.UInt32ToIp(0b11000000_10101000_00000000_00000001));

        }


    }
}
