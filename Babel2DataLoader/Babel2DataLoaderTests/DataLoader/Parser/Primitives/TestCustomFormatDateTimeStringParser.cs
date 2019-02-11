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
    public class TestCustomFormatDateTimeStringParser
    {
        [TestMethod()]
        public void CustomFormatDateTimeStringParser_ConvertYYYY_MM_DDTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetDateTimeParser(DateTimeFormatType.YYYY_MM_DD);
            var ex = new DateTime(2018, 9, 11);
            Assert.AreEqual("2018-09-11", isp.ConvertTo(ex));
            Assert.AreEqual(ex, isp.ConvertFrom("2018-09-11"));
        }
        [TestMethod()]
        public void CustomFormatDateTimeStringParser_ConvertYYYYMMDDTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetDateTimeParser(DateTimeFormatType.YYYYMMDD);
            var ex = new DateTime(2018, 9, 11);
            Assert.AreEqual("20180911", isp.ConvertTo(ex));
            Assert.AreEqual(ex, isp.ConvertFrom("20180911"));
        }
        [TestMethod()]
        public void CustomFormatDateTimeStringParser_ConvertDDMMYYYYTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetDateTimeParser("dd.MM.yyyy");
            var ex = new DateTime(2018, 9, 11);
            Assert.AreEqual("11.09.2018", isp.ConvertTo(ex));
            Assert.AreEqual(ex, isp.ConvertFrom("11.09.2018"));
        }
    }
}