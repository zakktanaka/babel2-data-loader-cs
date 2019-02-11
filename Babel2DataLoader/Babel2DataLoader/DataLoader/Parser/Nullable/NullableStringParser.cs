using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Parser.Nullable
{
    class NullableStringParser : IStringParser
    {
        private IStringParser underlyingStringParser;

        public Type TargetType { get; private set; }

        public NullableStringParser(Type targetType, IStringParser underlyingStringParser)
        {
            TargetType = targetType;
            this.underlyingStringParser = underlyingStringParser;
        }

        public object ConvertObjectFrom(string stringvalue)
        {
            if(string.IsNullOrEmpty(stringvalue))
            {
                return null;
            }

            return underlyingStringParser.ConvertObjectFrom(stringvalue);
        }

        public string ConvertObjectTo(object objectvalue)
        {
            if(objectvalue == null)
            {
                return null;
            }

            return underlyingStringParser.ConvertObjectTo(objectvalue);
        }
    }
}
