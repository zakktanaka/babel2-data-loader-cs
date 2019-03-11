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
    public class TestCsvWriter
    {
        [DataContract]
        class Hoge
        {
            [DataMember(Name = "id")]
            public int Id { get; set; }
        }

        [TestMethod()]
        public void CsvWriter_Test()
        {
            var ss = new StringWriter();
            using (var csv = CsvFactory.NewCsvFactory.GetWriter<Hoge>(ss))
            {
                csv.WriteRecord(new Hoge { Id = 1 });
                csv.WriteRecords(new List<Hoge>{
                    new Hoge { Id = 2 },
                    new Hoge { Id = 3 },
                });
            }

            var sb = new StringBuilder()
                .AppendLine("id")
                .AppendLine("1")
                .AppendLine("2")
                .AppendLine("3");

            Assert.AreEqual(sb.ToString(), ss.ToString());
        }
    }
}