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
    public class TestDateTimeStringParser
    {
        [TestMethod()]
        public void DateTimeStringParser_ConvertObjectTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetStringParser(typeof(DateTime));
            var ex = DateTime.Now.Date;
            Assert.AreEqual(ex.ToString(), isp.ConvertObjectTo(ex));
            Assert.AreEqual(ex, (DateTime)isp.ConvertObjectFrom(ex.ToString()));
        }
        [TestMethod()]
        public void DateTimeStringParser_ConvertTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var isp = rep.GetStringParser<DateTime>();
            var ex = DateTime.Now.Date;
            Assert.AreEqual(ex.ToString(), isp.ConvertTo(ex));
            Assert.AreEqual(ex, isp.ConvertFrom(ex.ToString()));
        }
    }
}