using System;

namespace Babel2.DataLoader.Parser.Enum
{
    class EnumStringParser : IStringParser
    {
        public Type TargetType { get; private set; }

        public EnumStringParser(Type enumType)
        {
            TargetType = enumType;
        }

        public object ConvertObjectFrom(string stringvalue)
        {
            return System.Enum.Parse(TargetType, stringvalue,true);
        }

        public string ConvertObjectTo(object objectvalue)
        {
            if (objectvalue.GetType() == TargetType)
            {
                return objectvalue.ToString();
            }

            throw new Exception("TODO");
        }
    }
}
