using Babel2.DataLoader.Parser;

namespace Babel2.DataLoader.Csv.TypeConvension
{
    public static class TypeConverterRepository
    {
        static TypeConverterRepository()
        {
            DefaultRepository = new TypeConverterRepositoryImpl(StringParserRepository.DefaultRepository);
        }

        public static ITypeConverterRepository DefaultRepository { get; }
    }
}
