using Microsoft.VisualStudio.TestTools.UnitTesting;
using Babel2.DataLoader.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Parser.Tests
{
    [TestClass()]
    public class TestNumberStringConverter
    {
        private static IStringParserRepository rep = StringParserRepository.DefaultRepository;

        [TestMethod()]
        public void NumberStringConverter_ConvertObjectShortTest()
        {
            var parser = rep.GetStringParser(typeof(short));
            Assert.AreEqual("42", parser.ConvertObjectTo((short)42));
            Assert.AreEqual(42, (short)parser.ConvertObjectFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertShortTest()
        {
            var parser = rep.GetStringParser<short>();
            Assert.AreEqual("42", parser.ConvertTo(42));
            Assert.AreEqual((short)42, parser.ConvertFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertObjectIntTest()
        {
            var parser = rep.GetStringParser(typeof(int));
            Assert.AreEqual("42", parser.ConvertObjectTo((int)42));
            Assert.AreEqual(42, (int)parser.ConvertObjectFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertIntTest()
        {
            var parser = rep.GetStringParser<int>();
            Assert.AreEqual("42", parser.ConvertTo(42));
            Assert.AreEqual((int)42, parser.ConvertFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertObjectLongTest()
        {
            var parser = rep.GetStringParser(typeof(long));
            Assert.AreEqual("42", parser.ConvertObjectTo((long)42));
            Assert.AreEqual(42, (long)parser.ConvertObjectFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertLongTest()
        {
            var parser = rep.GetStringParser<long>();
            Assert.AreEqual("42", parser.ConvertTo(42));
            Assert.AreEqual((long)42, parser.ConvertFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertObjectFloatTest()
        {
            var parser = rep.GetStringParser(typeof(float));
            Assert.AreEqual("42", parser.ConvertObjectTo((float)42));
            Assert.AreEqual(42, (float)parser.ConvertObjectFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertFloatTest()
        {
            var parser = rep.GetStringParser<float>();
            Assert.AreEqual("42", parser.ConvertTo(42));
            Assert.AreEqual((float)42, parser.ConvertFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertObjectDoubleTest()
        {
            var parser = rep.GetStringParser(typeof(double));
            Assert.AreEqual("42", parser.ConvertObjectTo((double)42));
            Assert.AreEqual(42, (double)parser.ConvertObjectFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertDoubleTest()
        {
            var parser = rep.GetStringParser<double>();
            Assert.AreEqual("42", parser.ConvertTo(42));
            Assert.AreEqual((double)42, parser.ConvertFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertObjectUshortTest()
        {
            var parser = rep.GetStringParser(typeof(ushort));
            Assert.AreEqual("42", parser.ConvertObjectTo((ushort)42));
            Assert.AreEqual(42, (ushort)parser.ConvertObjectFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertUshortTest()
        {
            var parser = rep.GetStringParser<ushort>();
            Assert.AreEqual("42", parser.ConvertTo(42));
            Assert.AreEqual((ushort)42, parser.ConvertFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertObjectUintTest()
        {
            var parser = rep.GetStringParser(typeof(uint));
            Assert.AreEqual("42", parser.ConvertObjectTo((uint)42));
            Assert.AreEqual((uint)42, (uint)parser.ConvertObjectFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertUintTest()
        {
            var parser = rep.GetStringParser<uint>();
            Assert.AreEqual("42", parser.ConvertTo(42));
            Assert.AreEqual((uint)42, parser.ConvertFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertObjectUlongTest()
        {
            var parser = rep.GetStringParser(typeof(ulong));
            Assert.AreEqual("42", parser.ConvertObjectTo((ulong)42));
            Assert.AreEqual((ulong)42, (ulong)parser.ConvertObjectFrom("42"));
        }
        [TestMethod()]
        public void NumberStringConverter_ConvertUlongTest()
        {
            var parser = rep.GetStringParser<ulong>();
            Assert.AreEqual("42", parser.ConvertTo(42));
            Assert.AreEqual((ulong)42, parser.ConvertFrom("42"));
        }
    }
}