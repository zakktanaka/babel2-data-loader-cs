using Babel2.DataLoader.Parser;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Babel2.DataLoader.Csv.TypeConvension
{
    class TypeConverterImpl : ITypeConverter
    {
        private IStringParser parser;

        public TypeConverterImpl(IStringParser parser)
        {
            this.parser = parser;
        }

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return parser.ConvertObjectFrom(text);
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return parser.ConvertObjectTo(value);
        }
    }
}
