using System;

namespace Babel2.DataLoader.Parser
{
    abstract class NumberStringConverter<T> : AbstractStringParser<T> where T : struct
    {
        public abstract T Convert(string stringvalue);
        public abstract string Convert(T objectvalue);

        public override T ConvertFrom(string stringvalue)
        {
            if (stringvalue == null)
            {
                throw new Exception("TODO");
            }

            return Convert(stringvalue);
        }

        public override string ConvertTo(T objectvalue)
        {
            return Convert(objectvalue);
        }
    }

    class ByteStringConverter : NumberStringConverter<byte>
    {
        public override byte Convert(string stringvalue) => byte.Parse(stringvalue);
        public override string Convert(byte objectvalue) => objectvalue.ToString();
    }
    class SbyteStringConverter : NumberStringConverter<sbyte>
    {
        public override sbyte Convert(string stringvalue) => sbyte.Parse(stringvalue);
        public override string Convert(sbyte objectvalue) => objectvalue.ToString();
    }
    class ShortStringConverter : NumberStringConverter<short>
    {
        public override short Convert(string stringvalue) => short.Parse(stringvalue);
        public override string Convert(short objectvalue) => objectvalue.ToString();
    }
    class UshortStringConverter : NumberStringConverter<ushort>
    {
        public override ushort Convert(string stringvalue) => ushort.Parse(stringvalue);
        public override string Convert(ushort objectvalue) => objectvalue.ToString();
    }
    class IntStringConverter : NumberStringConverter<int>
    {
        public override int Convert(string stringvalue) => int.Parse(stringvalue);
        public override string Convert(int objectvalue) => objectvalue.ToString();
    }
    class UintStringConverter : NumberStringConverter<uint>
    {
        public override uint Convert(string stringvalue) => uint.Parse(stringvalue);
        public override string Convert(uint objectvalue) => objectvalue.ToString();
    }
    class LongStringConverter : NumberStringConverter<long>
    {
        public override long Convert(string stringvalue) => long.Parse(stringvalue);
        public override string Convert(long objectvalue) => objectvalue.ToString();
    }
    class UlongStringConverter : NumberStringConverter<ulong>
    {
        public override ulong Convert(string stringvalue) => ulong.Parse(stringvalue);
        public override string Convert(ulong objectvalue) => objectvalue.ToString();
    }
    class FloatStringConverter : NumberStringConverter<float>
    {
        public override float Convert(string stringvalue) => float.Parse(stringvalue);
        public override string Convert(float objectvalue) => objectvalue.ToString();
    }
    class DoubleStringConverter : NumberStringConverter<double>
    {
        public override double Convert(string stringvalue) => double.Parse(stringvalue);
        public override string Convert(double objectvalue) => objectvalue.ToString();
    }
}
