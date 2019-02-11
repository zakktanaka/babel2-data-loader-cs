using System;

namespace Babel2.DataLoader.Parser
{
    public enum DateTimeFormatType
    {
        YYYY_MM_DD,
        YYYYMMDD,
    }
}

namespace Babel2.DataLoader.Parser.Extensions
{
    static class DateTimeFormatTypeExtension
    {
        public static string GetValue(this DateTimeFormatType formatType)
        {
            switch(formatType)
            {
                case DateTimeFormatType.YYYY_MM_DD: return "yyyy-MM-dd";
                case DateTimeFormatType.YYYYMMDD: return "yyyyMMdd";
            }

            throw new Exception("TODO");
        }
    }
}
