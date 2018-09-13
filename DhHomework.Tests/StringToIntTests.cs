using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DhHomework.Tests
{
    [TestClass]
    public class StringToIntTests
    {
        [TestMethod]
        public void Decimal()
        {
            Assert.AreEqual(12345, StringToInt.Stoi("12345", out var idx, 10));
            Assert.AreEqual("12345".Length, idx);
        }

        [TestMethod]
        public void HexaDecimal()
        {
            Assert.AreEqual(19918245, StringToInt.Stoi("12FEDA5", out var idx, 16));
            Assert.AreEqual("12FEDA5".Length, idx);
        }

        [TestMethod]
        public void Octal()
        {
            Assert.AreEqual(46396, StringToInt.Stoi("132474", out var idx, 8));
            Assert.AreEqual("132474".Length, idx);
        }

        [TestMethod]
        public void WhiteSpacePrefixAndSuffix()
        {
            Assert.AreEqual(45735, StringToInt.Stoi("    zaf-=137198274nf", out var idx, 36));
            Assert.AreEqual("    zaf".Length, idx);
        }

        [TestMethod]
        public void Base0DetectBase16()
        {
            Assert.AreEqual(44810, StringToInt.Stoi("    0xAF0A-=137198274nf", out var idx, 0));
            Assert.AreEqual("    0xAF0A".Length, idx);
        }

        [TestMethod]
        public void Base0DetectDecimal()
        {
            Assert.AreEqual(3546752, StringToInt.Stoi("    3546752-=137198274nf", out var idx, 0));
            Assert.AreEqual("    3546752".Length, idx);
        }
    }
}
