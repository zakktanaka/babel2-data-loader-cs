using System;

namespace Babel2.DataLoader.Parser
{
    public interface IStringParser
    {
        object ConvertObjectFrom(string stringvalue);
        string ConvertObjectTo(object objectvalue);
        Type TargetType { get; }
    }
}
