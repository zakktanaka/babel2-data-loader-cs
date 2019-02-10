using Microsoft.VisualStudio.TestTools.UnitTesting;
using Babel2.DataLoader.Parser.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Parser.Primitives.Tests
{
    [TestClass()]
    public class TestBoolStringConverter
    {
        [TestMethod()]
        public void BoolStringConverter_ConvertObjectTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetStringParser(typeof(bool));
            Assert.AreEqual(true.ToString(), isp.ConvertObjectTo(true));
            Assert.AreEqual(false.ToString(), isp.ConvertObjectTo(false));

            Assert.IsTrue((bool)isp.ConvertObjectFrom("true"));
            Assert.IsTrue((bool)isp.ConvertObjectFrom("TRUE"));

            Assert.IsFalse((bool)isp.ConvertObjectFrom("false"));
            Assert.IsFalse((bool)isp.ConvertObjectFrom("FALSE"));
        }
        [TestMethod()]
        public void BoolStringConverter_ConvertTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetStringParser<bool>();
            Assert.AreEqual(true.ToString(), isp.ConvertTo(true));
            Assert.AreEqual(false.ToString(), isp.ConvertTo(false));

            Assert.IsTrue(isp.ConvertFrom("true"));
            Assert.IsTrue(isp.ConvertFrom("TRUE"));

            Assert.IsFalse(isp.ConvertFrom("false"));
            Assert.IsFalse(isp.ConvertFrom("FALSE"));
        }
    }
}