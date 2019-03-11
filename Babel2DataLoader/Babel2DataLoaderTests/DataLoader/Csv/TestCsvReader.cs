using Microsoft.VisualStudio.TestTools.UnitTesting;
using Babel2.DataLoader.Csv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;

namespace Babel2.DataLoader.Csv.Tests
{
    [TestClass()]
    public class TestCsvReader
    {
        [DataContract]
        class Hoge
        {
            [DataMember(Name = "id")]
            public int Id { get; set; }
        }

        [TestMethod()]
        public void CsvReader_Test()
        {
            var sb = new StringBuilder()
                .AppendLine("id")
                .Append("1");

            using (var ss = new StringReader(sb.ToString()))
            using (var csv = CsvFactory.NewCsvFactory.GetReader<Hoge>(ss))
            {

                foreach (var hoge in csv.Records)
                {
                    Assert.AreEqual(1, hoge.Id);
                }
            }

        }
    }
}