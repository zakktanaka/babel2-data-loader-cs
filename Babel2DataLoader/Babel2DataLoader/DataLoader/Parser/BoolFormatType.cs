using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Parser
{
    public enum BoolFormatType
    {
        YesOrNo,
        YorN,
    }
}

namespace Babel2.DataLoader.Parser.Extensions
{
    static class BoolFormatTypeExtension
    {
        public static Tuple<string[], string[]> GetValue(this BoolFormatType formatType)
        {
            switch (formatType)
            {
                case BoolFormatType.YesOrNo: return Tuple.Create(new string[] { "Yes"}, new string[] { "No"});
                case BoolFormatType.YorN: return Tuple.Create(new string[] { "Y" }, new string[] { "N" });
            }

            throw new Exception("TODO");
        }
    }
}
