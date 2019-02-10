using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Parser.Primitives
{
    class BoolStringConverter : AbstractStringParser<bool>
    {
        public override bool ConvertFrom(string stringvalue)
        {
            return bool.Parse(stringvalue);
        }

        public override string ConvertTo(bool objectvalue)
        {
            return objectvalue.ToString();
        }
    }
}
