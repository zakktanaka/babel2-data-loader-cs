﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Parser.Collections
{
    static class CollectionParserHelper
    {
        private static string Disc = ",";
        private static char[] Discs = new char[] { ',' };

        public static IEnumerable ConvertElementsFrom(string stringvalue, IStringParser elementParser)
        {
            var sval = stringvalue == null ? string.Empty : stringvalue.Trim();
            if (!string.IsNullOrEmpty(sval))
            {
                foreach (var value in sval.Split(Discs))
                {
                    yield return elementParser.ConvertObjectFrom(value);
                }
            }
        }

        public static IEnumerable<string> ConvertElementsTo(object objectvalue, IStringParser elementParser)
        {
            foreach (var value in (IEnumerable) objectvalue)
            {
                yield return elementParser.ConvertObjectTo(value);
            }
        }

        public static string ConcatValues(IEnumerable<string> values)
        {
            return string.Join(Disc,values);
        }
    }
}
