using System;

namespace Babel2.DataLoader.Parser
{
    public interface IStringParserRepository
    {
        IStringParser<T> GetStringParser<T>();
        IStringParser GetStringParser(Type type);
    }
}
