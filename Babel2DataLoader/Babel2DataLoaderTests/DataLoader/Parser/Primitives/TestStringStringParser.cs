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
    public class TestStringStringParser
    {
        [TestMethod()]
        public void StringStringParser_ConvertObjectTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetStringParser(typeof(string));
            Assert.AreEqual("HOGE", isp.ConvertObjectTo("HOGE"));
            Assert.AreEqual("HOHE", (string)isp.ConvertObjectFrom("HOHE"));
        }
        [TestMethod()]
        public void StringStringParser_ConvertTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetStringParser<string>();
            Assert.AreEqual("HOGE", isp.ConvertTo("HOGE"));
            Assert.AreEqual("HOHE", isp.ConvertFrom("HOHE"));
        }
    }
}