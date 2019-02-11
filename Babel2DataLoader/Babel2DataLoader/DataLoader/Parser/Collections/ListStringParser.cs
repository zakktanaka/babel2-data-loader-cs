using Babel2.DataLoader.Utilities;
using System;
using System.Collections;

namespace Babel2.DataLoader.Parser.Collections
{
    class ListStringParser : IStringParser
    {
        private IStringParser elementStringParser;

        public Type TargetType { get; private set; }

        public ListStringParser(Type targetType, IStringParser elementStringParser)
        {
            TargetType = targetType;
            this.elementStringParser = elementStringParser;
        }

        public object ConvertObjectFrom(string stringvalue)
        {
            var collection = (IList)TargetType.GetDefaultConstructor().Invoke(Type.EmptyTypes); 

            if (string.IsNullOrEmpty(stringvalue))
            {
                return collection;
            }

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
