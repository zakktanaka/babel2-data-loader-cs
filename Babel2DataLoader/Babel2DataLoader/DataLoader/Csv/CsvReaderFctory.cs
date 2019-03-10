using Babel2.DataLoader.Csv.Configurations;

namespace Babel2.DataLoader.Csv
{
    public static class CsvReaderFctory
    {
        public static ICsvReaderFctory NewCsvReaderFctory
        {
            get
            {
                return new CsvReaderFctoryImpl(CsvConfigurationRepository.DefaultRepository);
            }
        }

    }
}
