using Babel2.DataLoader.Utilities;
using System;
using System.Collections;
using System.Reflection;

namespace Babel2.DataLoader.Parser.Collections
{
    class ListStringParser : IStringParser
    {
        private IStringParser elementStringParser;
        private ConstructorInfo constructorinfo;

        public Type TargetType { get; private set; }

        public ListStringParser(Type targetType, IStringParser elementStringParser)
        {
            TargetType = targetType;
            this.elementStringParser = elementStringParser;
            this.constructorinfo = targetType.GetDefaultConstructor();
        }

        public object ConvertObjectFrom(string stringvalue)
        {
            var collection = (IList)constructorinfo.Invoke(Type.EmptyTypes); 

            foreach(var value in CollectionParserHelper.ConvertElementsFrom(stringvalue, elementStringParser))
            {
                collection.Add(value);
            }

            return collection;
        }

        public string ConvertObjectTo(object objectvalue)
        {
            if (objectvalue == null)
            {
                return string.Empty;
            }

            return CollectionParserHelper.ConcatValues(
                CollectionParserHelper.ConvertElementsTo(objectvalue, elementStringParser)
                );
        }
    }
}
