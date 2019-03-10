using Babel2.DataLoader.Csv.Configurations;
using System.IO;

namespace Babel2.DataLoader.Csv
{
    class CsvReaderFctoryImpl : ICsvReaderFctory
    {
        private ICsvConfigurationRepository csvConfigurationRepository;

        public CsvReaderFctoryImpl(ICsvConfigurationRepository csvConfigurationRepository)
        {
            this.csvConfigurationRepository = csvConfigurationRepository;
        }

        public ICsvReader<T> GetReader<T>(TextReader tr)
        {
            return new CsvReaderImpl<T>(tr, csvConfigurationRepository.GetConfiguration<T>());
        }
    }
}
