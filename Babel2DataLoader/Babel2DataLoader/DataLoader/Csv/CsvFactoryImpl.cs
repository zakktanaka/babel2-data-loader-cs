using Babel2.DataLoader.Csv.Configurations;
using System.IO;

namespace Babel2.DataLoader.Csv
{
    class CsvFactoryImpl : ICsvFactory
    {
        private ICsvConfigurationRepository csvConfigurationRepository;

        public CsvFactoryImpl(ICsvConfigurationRepository csvConfigurationRepository)
        {
            this.csvConfigurationRepository = csvConfigurationRepository;
        }

        public ICsvReader<T> GetReader<T>(TextReader tr)
        {
            return new CsvReaderImpl<T>(tr, csvConfigurationRepository.GetConfiguration<T>());
        }

        public ICsvWriter<T> GetWriter<T>(TextWriter tw)
        {
            return new CsvWriterImpl<T>(tw, csvConfigurationRepository.GetConfiguration<T>());
        }
    }
}
