using Babel2.DataLoader.Parser;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Concurrent;

namespace Babel2.DataLoader.Csv.TypeConvension
{
    class TypeConverterRepositoryImpl : ITypeConverterRepository
    {
        private IStringParserRepository repo;
        private ConcurrentDictionary<Type, Lazy<ITypeConverter>> cache;

        public TypeConverterRepositoryImpl(IStringParserRepository stringParserRepository)
        {
            cache = new ConcurrentDictionary<Type, Lazy<ITypeConverter>>();
            repo = stringParserRepository;
        }

        public ITypeConverter GetBoolTypeConverter(BoolFormatType formatType)
        {
            return new TypeConverterImpl(repo.GetBoolParser(formatType));
        }

        public ITypeConverter GetDateTimeTypeConverter(DateTimeFormatType formatType)
        {
            return new TypeConverterImpl(repo.GetDateTimeParser(formatType));
        }

        public ITypeConverter GetDateTimeTypeConverter(string format)
        {
            return new TypeConverterImpl(repo.GetDateTimeParser(format));
        }

        public ITypeConverter GetTypeConverter(Type type)
        {
            return cache.GetOrAdd(type, new Lazy<ITypeConverter>(() => new TypeConverterImpl(repo.GetStringParser(type)))).Value;
        }

        public ITypeConverter GetTypeConverter<T>()
        {
            return GetTypeConverter(typeof(T));
        }
    }
}
