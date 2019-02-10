using Microsoft.VisualStudio.TestTools.UnitTesting;
using Babel2.DataLoader.Parser.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Parser.Enums.Tests
{
    [TestClass()]
    public class TestEnumStringParser
    {
        enum HType { Hoge, Hege,}
        [TestMethod()]
        public void EnumStringParser_ConvertObjectTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetStringParser(typeof(HType));
            Assert.AreEqual("Hoge", isp.ConvertObjectTo(HType.Hoge));
            Assert.AreEqual("Hege", isp.ConvertObjectTo(HType.Hege));
            Assert.AreEqual(HType.Hege, (HType)isp.ConvertObjectFrom("Hege"));
            Assert.AreEqual(HType.Hege, (HType)isp.ConvertObjectFrom("hege"));
            Assert.AreEqual(HType.Hege, (HType)isp.ConvertObjectFrom("HEGE"));
        }
        [TestMethod()]
        public void EnumStringParser_ConvertTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetStringParser<HType>();
            Assert.AreEqual("Hoge", isp.ConvertObjectTo(HType.Hoge));
            Assert.AreEqual("Hege", isp.ConvertObjectTo(HType.Hege));
            Assert.AreEqual(HType.Hege, (HType)isp.ConvertObjectFrom("Hege"));
            Assert.AreEqual(HType.Hege, (HType)isp.ConvertObjectFrom("hege"));
            Assert.AreEqual(HType.Hege, (HType)isp.ConvertObjectFrom("HEGE"));

            Assert.AreEqual("Hoge", isp.ConvertTo(HType.Hoge));
            Assert.AreEqual("Hege", isp.ConvertTo(HType.Hege));
            Assert.AreEqual(HType.Hege, isp.ConvertFrom("Hege"));
            Assert.AreEqual(HType.Hege, isp.ConvertFrom("hege"));
            Assert.AreEqual(HType.Hege, isp.ConvertFrom("HEGE"));
        }
    }
}