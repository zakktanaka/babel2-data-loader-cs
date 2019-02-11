﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Babel2.DataLoader.Parser.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Parser.Collections.Tests
{
    [TestClass()]
    public class TestListStringParser
    {
        [TestMethod()]
        public void ListStringParser_ConvertObjectTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var list = new List<int> { 0, 1, 2, 3, 4, };
            var isp = rep.GetStringParser(list.GetType());
            Assert.AreEqual("0,1,2,3,4", isp.ConvertObjectTo(list));
            Assert.IsTrue(Enumerable.SequenceEqual(list, (List<int>)isp.ConvertObjectFrom("0,1,2,3,4")));
            Assert.IsTrue(Enumerable.SequenceEqual(list, (List<int>)isp.ConvertObjectFrom("  0, 1 ,  2 ,3,4 ")));
        }
        [TestMethod()]
        public void ListStringParser_ConvertTest()
        {
            var rep = StringParserRepository.DefaultRepository;
            var list = new List<int> { 0, 1, 2, 3, 4, };
            var isp = rep.GetStringParser<List<int>>();
            Assert.AreEqual("0,1,2,3,4", isp.ConvertTo(list));
            Assert.IsTrue(Enumerable.SequenceEqual(list, isp.ConvertFrom("0,1,2,3,4")));
            Assert.IsTrue(Enumerable.SequenceEqual(list, isp.ConvertFrom("  0, 1 ,  2 ,3,4 ")));

            Assert.AreEqual("0,1,2,3,4", isp.ConvertObjectTo(list));
            Assert.IsTrue(Enumerable.SequenceEqual(list, (List<int>)isp.ConvertObjectFrom("0,1,2,3,4")));
            Assert.IsTrue(Enumerable.SequenceEqual(list, (List<int>)isp.ConvertObjectFrom("  0, 1 ,  2 ,3,4 ")));
        }
    }
}