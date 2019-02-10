using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Parser.Primitives
{
    class DateTimeStringParser : AbstractStringParser<DateTime>
    {
        public override DateTime ConvertFrom(string stringvalue)
        {
            return DateTime.Parse(stringvalue);
        }

        public override string ConvertTo(DateTime objectvalue)
        {
            return objectvalue.ToString();
        }
    }
}
