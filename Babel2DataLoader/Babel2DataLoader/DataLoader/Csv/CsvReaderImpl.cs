using Babel2.DataLoader.Csv.Configurations;
using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Babel2.DataLoader.Csv
{
    class CsvReaderImpl<T> : ICsvReader<T>
    {
        private CsvReader csv;

        public CsvReaderImpl(TextReader tr, CsvConfiguration configuration)
        {
            csv = new CsvReader(tr, configuration.CsvHelperConfiguration);
        }

        public void Dispose()
        {
            csv.Dispose();
        }

        public IEnumerable<T> Records {
            get
            {
                return csv.GetRecords<T>();
            }
        }
    }
}
