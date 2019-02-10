namespace Babel2.DataLoader.Parser.Primitives
{
    class StringStringParser : AbstractStringParser<string>
    {
        public override string ConvertFrom(string stringvalue)
        {
            return stringvalue;
        }

        public override string ConvertTo(string objectvalue)
        {
            return objectvalue;
        }
    }
}
