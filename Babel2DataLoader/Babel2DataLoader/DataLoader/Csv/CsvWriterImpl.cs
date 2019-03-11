using Babel2.DataLoader.Csv.Configurations;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Csv
{
    class CsvWriterImpl<T> : ICsvWriter<T>
    {
        private CsvWriter csv;

        public CsvWriterImpl(TextWriter tr, CsvConfiguration configuration)
        {
            csv = new CsvWriter(tr, configuration.CsvHelperConfiguration);
            csv.WriteHeader<T>();
            csv.NextRecord();
        }

        public void Dispose()
        {
            csv.Dispose();
        }

        public ICsvWriter<T> WriteRecord(T record)
        {
            csv.WriteRecord(record);
            csv.NextRecord();
            return this;
        }

        public ICsvWriter<T> WriteRecords(IEnumerable<T> records)
        {
            csv.WriteRecords(records);
            return this;
        }
    }
}
