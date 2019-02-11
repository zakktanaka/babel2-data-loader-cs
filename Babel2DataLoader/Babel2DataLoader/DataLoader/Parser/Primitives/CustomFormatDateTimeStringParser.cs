using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Parser.Primitives
{
    class CustomFormatDateTimeStringParser : AbstractStringParser<DateTime>
    {
        private string format;

        public CustomFormatDateTimeStringParser(string format)
        {
            this.format = format;
        }

        public override DateTime ConvertFrom(string stringvalue)
        {
            return DateTime.ParseExact(stringvalue.Trim(), format,null);
        }

        public override string ConvertTo(DateTime objectvalue)
        {
            return objectvalue.ToString(format);
        }
    }
}
