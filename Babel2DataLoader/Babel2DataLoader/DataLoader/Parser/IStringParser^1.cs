namespace Babel2.DataLoader.Parser
{
    public interface IStringParser<T> : IStringParser
    {
        T ConvertFrom(string stringvalue);
        string ConvertTo(T objectvalue);
    }
}
