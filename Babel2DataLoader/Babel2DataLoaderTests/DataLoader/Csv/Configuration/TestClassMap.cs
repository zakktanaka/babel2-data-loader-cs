using Microsoft.VisualStudio.TestTools.UnitTesting;
using Babel2.DataLoader.Csv.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using CsvHelper.TypeConversion;
using CsvHelper;
using CsvHelper.Configuration;

namespace Babel2.DataLoader.Csv.Configuration.Tests
{
    class ClassMapImpl : CsvHelper.Configuration.ClassMap<Hoge>
    {
        public ClassMapImpl()
        {
            foreach(var propinfo in typeof(Hoge).GetProperties())
            {
                var m = Map(typeof(Hoge), propinfo);
                if(m.Data.TypeConverter == null)
                {
                    m.TypeConverter(new Conv());
                }
            }
        }
    }

    class Conv : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return new Fuga { Code = text };
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return (value as Fuga)?.Code ?? string.Empty;
        }
    }

    class Fuga
    {
        public string Code;
    }
    class Hoge
    {
        public Fuga Fuga { get; set; }
        public List<int> Hega { get; set; }
    }

    [TestClass()]
    public class TestClassMap
    {
        [TestMethod()]
        public void ClassMap_ClassMapTest()
        {
            var sb = new StringBuilder()
                .AppendLine("fuga,Hega")
                //.AppendLine("124  ,,\"1\"")
                //.AppendLine(",sss,\"2\"")
                //.AppendLine()
                .AppendLine("123,\"3,4\"")
                ;

            Console.WriteLine(sb.ToString());

            //using (var sr = new StringReader(sb.ToString()))
            //using (var csv = new CsvHelper.CsvReader(sr))
            //{
            //    csv.Configuration.PrepareHeaderForMatch = (header, index) => header.Trim().ToLower(); 
            //    csv.Configuration.RegisterClassMap<ClassMapImpl>();

            //    csv.Read();
            //    csv.ReadHeader();
            //    while (csv.Read())
            //    {
            //        var d = csv.GetRecord<Hoge>();

            //        Console.WriteLine("-" + d.Fuga.Code + "-");
            //        foreach (var h in csv.Context.HeaderRecord)
            //        {
            //            Console.WriteLine($"{h}, {csv.GetField(h)}");
            //        }
            //    }

            //    var records = csv.GetRecords<Hoge>();
            //    //foreach (var data in records)
            //    //{
            //    //    Console.WriteLine(data.Fuga.Code);
            //    //}
            //}

            var srr = new StringWriter();
            using (var csv = new CsvHelper.CsvWriter(srr))
            {
                csv.Configuration.RegisterClassMap<ClassMapImpl>();

                var hoges = new List<Hoge>
                {
                    new Hoge{Fuga = new Fuga{ Code ="code" }, Hega = new List<int>{ 2,3,} },
                    //new Hoge{ },
                    //new Hoge{Fuga = new Fuga{ Code = "11,333"} },
                    //new Hoge{Fuga = new Fuga{ Code = "hega\r\nfuga"} },
                    //new Hoge{Fuga = new Fuga{ Code = "11"} },
                };

                csv.WriteHeader<Hoge>();
                csv.NextRecord();
                foreach (var hoge in hoges)
                {
                    csv.WriteRecord(hoge);
                }

            }
            Console.WriteLine(srr.ToString());
        }
    }
}