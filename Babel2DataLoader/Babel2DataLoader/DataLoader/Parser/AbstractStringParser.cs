using System;

namespace Babel2.DataLoader.Parser
{
    public abstract class AbstractStringParser<T> : IStringParser<T>
    {
        public Type TargetType => typeof(T);

        public abstract T ConvertFrom(string stringvalue);
        public abstract string ConvertTo(T objectvalue);


        public object ConvertObjectFrom(string stringvalue)
        {
            return ConvertFrom(stringvalue);
        }

        public string ConvertObjectTo(object objectvalue)
        {
            return ConvertTo((T) objectvalue);
        }
    }
}
