using Babel2.DataLoader.Csv.TypeConvension;
using Babel2.DataLoader.Parser;
using System;
using System.Collections.Concurrent;

namespace Babel2.DataLoader.Csv.Configurations
{
    class CsvConfigurationRepositoryImpl : ICsvConfigurationRepository
    {
        private ConcurrentDictionary<Type, Lazy<CsvConfiguration>> cache;
        private CsvConfigurationFactory factory;

        public CsvConfigurationRepositoryImpl(IStringParserRepository parserRepository)
        {
            cache = new ConcurrentDictionary<Type, Lazy<CsvConfiguration>>();
            factory = new CsvConfigurationFactory(
                parserRepository,
                new TypeConverterRepositoryImpl(parserRepository)
                );
        }

        public CsvConfiguration GetConfiguration<T>()
        {
            return cache.GetOrAdd(
                typeof(T), 
                new Lazy<CsvConfiguration>(() => factory.GetConfiguration<T>())
                ).Value;
        }
    }
}
