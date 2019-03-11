using Babel2.DataLoader.Csv.Configurations;

namespace Babel2.DataLoader.Csv
{
    public static class CsvFactory
    {
        public static ICsvFactory NewCsvFactory
        {
            get
            {
                return new CsvFactoryImpl(CsvConfigurationRepository.DefaultRepository);
            }
        }
    }
}
