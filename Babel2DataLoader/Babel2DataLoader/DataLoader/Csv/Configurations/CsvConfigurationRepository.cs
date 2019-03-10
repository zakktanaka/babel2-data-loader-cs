using Babel2.DataLoader.Parser;

namespace Babel2.DataLoader.Csv.Configurations
{
    public static class CsvConfigurationRepository
    {

        static CsvConfigurationRepository()
        {
            DefaultRepository = new CsvConfigurationRepositoryImpl(StringParserRepository.DefaultRepository);
        }

        public static ICsvConfigurationRepository DefaultRepository { get; }
        

    }
}
