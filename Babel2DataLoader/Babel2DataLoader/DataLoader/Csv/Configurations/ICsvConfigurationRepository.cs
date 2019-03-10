namespace Babel2.DataLoader.Csv.Configurations
{
    public interface ICsvConfigurationRepository
    {
        CsvConfiguration GetConfiguration<T>();
    }
}
