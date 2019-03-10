using Babel2.DataLoader.Parser;
using CsvHelper.TypeConversion;
using System;

namespace Babel2.DataLoader.Csv.TypeConvension
{
    public interface ITypeConverterRepository
    {
        ITypeConverter GetTypeConverter(Type type);
        ITypeConverter GetTypeConverter<T>();
        ITypeConverter GetDateTimeTypeConverter(DateTimeFormatType formatType);
        ITypeConverter GetDateTimeTypeConverter(string format);
        ITypeConverter GetBoolTypeConverter(BoolFormatType formatType);
    }
}
