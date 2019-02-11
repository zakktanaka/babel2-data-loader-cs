using Microsoft.VisualStudio.TestTools.UnitTesting;
using Babel2.DataLoader.Parser.Nullable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Parser.Nullable.Tests
{
    [TestClass()]
    public class TestNullableStringParser
    {
        [TestMethod()]
        public void NullableStringParser_ConvertObjectTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetStringParser(typeof(int?));

            Assert.AreEqual(null, isp.ConvertObjectFrom(null));
            Assert.AreEqual(null, isp.ConvertObjectFrom(""));
            Assert.AreEqual(42, (int)isp.ConvertObjectFrom("42"));

            Assert.AreEqual(null, isp.ConvertObjectTo(null));
            Assert.AreEqual("42", isp.ConvertObjectTo(42));
        }
        [TestMethod()]
        public void NullableStringParser_ConvertTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetStringParser<int?>();

            Assert.AreEqual(null, isp.ConvertFrom(null));
            Assert.AreEqual(null, isp.ConvertFrom(""));
            Assert.AreEqual(42, isp.ConvertFrom("42"));

            Assert.AreEqual(null, isp.ConvertTo(null));
            Assert.AreEqual("42", isp.ConvertTo(42));

            Assert.AreEqual(null, isp.ConvertObjectFrom(null));
            Assert.AreEqual(null, isp.ConvertObjectFrom(""));
            Assert.AreEqual(42, (int)isp.ConvertObjectFrom("42"));

            Assert.AreEqual(null, isp.ConvertObjectTo(null));
            Assert.AreEqual("42", isp.ConvertObjectTo(42));
        }
    }
}