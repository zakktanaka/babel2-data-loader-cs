using System;

namespace Babel2.DataLoader.Parser
{
    public interface IStringParserRepository
    {
        IStringParser<T> GetStringParser<T>();
        IStringParser GetStringParser(Type type);
        IStringParser<DateTime> GetDateTimeParser(DateTimeFormatType formatType);
        IStringParser<DateTime> GetDateTimeParser(string format);
        IStringParser<bool> GetBoolParser(BoolFormatType formatType);
        IStringParserRepository UpdateStringParser(IStringParser parser);
    }
}
