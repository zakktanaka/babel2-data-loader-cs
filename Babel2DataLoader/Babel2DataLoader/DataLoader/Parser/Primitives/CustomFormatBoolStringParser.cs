using System;
using System.Linq;

namespace Babel2.DataLoader.Parser.Primitives
{
    class CustomFormatBoolStringParser : AbstractStringParser<bool>
    {
        private string[] trues;
        private string[] falses;
        private string[] ts;
        private string[] fs;

        public CustomFormatBoolStringParser(string[] trues, string[] falses)
        {
            this.trues = trues;
            this.falses = falses;
            ts = trues.Select(t => t.ToLower()).ToArray();
            fs = falses.Select(t => t.ToLower()).ToArray();
        }

        public override bool ConvertFrom(string stringvalue)
        {
            var sval = stringvalue.Trim().ToLower();
            if(ts.Contains(sval)) { return true; }
            if(fs.Contains(sval)) { return false; }
            throw new Exception("TODO");
        }

        public override string ConvertTo(bool objectvalue)
        {
            return objectvalue ? trues[0] : falses[0];
        }
    }
}
