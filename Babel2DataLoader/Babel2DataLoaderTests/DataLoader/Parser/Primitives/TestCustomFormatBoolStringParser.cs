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
    public class TestCustomFormatBoolStringParser
    {
        [TestMethod()]
        public void CustomFormatBoolStringParser_ConvertYesOrNoTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetBoolParser(BoolFormatType.YesOrNo);
            Assert.AreEqual("Yes", isp.ConvertTo(true));
            Assert.AreEqual("No", isp.ConvertTo(false));

            Assert.IsTrue(isp.ConvertFrom("YES"));
            Assert.IsTrue(isp.ConvertFrom("yes"));

            Assert.IsFalse(isp.ConvertFrom("NO"));
            Assert.IsFalse(isp.ConvertFrom("no    "));
        }
        [TestMethod()]
        public void CustomFormatBoolStringParser_ConvertYorNTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetBoolParser(BoolFormatType.YorN);
            Assert.AreEqual("Y", isp.ConvertTo(true));
            Assert.AreEqual("N", isp.ConvertTo(false));

            Assert.IsTrue(isp.ConvertFrom(" Y"));
            Assert.IsTrue(isp.ConvertFrom("y"));

            Assert.IsFalse(isp.ConvertFrom("N"));
            Assert.IsFalse(isp.ConvertFrom("n    "));
        }
    }
}