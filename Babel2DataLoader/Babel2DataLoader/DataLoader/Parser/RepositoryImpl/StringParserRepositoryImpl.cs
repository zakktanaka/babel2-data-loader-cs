using Babel2.DataLoader.Parser.Collections;
using Babel2.DataLoader.Parser.Enum;
using Babel2.DataLoader.Parser.Extensions;
using Babel2.DataLoader.Parser.Nullable;
using Babel2.DataLoader.Parser.Primitives;
using Babel2.DataLoader.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Babel2.DataLoader.Parser.RepositoryImpl
{
    class StringParserRepositoryImpl : IStringParserRepository
    {
        private static ConcurrentDictionary<Type, Lazy<IStringParser>> cache;
        private static ConcurrentDictionary<string, Lazy<IStringParser<DateTime>>> datetimecache;
        private static ConcurrentDictionary<BoolFormatType, Lazy<IStringParser<bool>>> boolcache;

        static StringParserRepositoryImpl()
        {
            datetimecache = new ConcurrentDictionary<string, Lazy<IStringParser<DateTime>>>();
            boolcache = new ConcurrentDictionary<BoolFormatType, Lazy<IStringParser<bool>>>();
            cache = new ConcurrentDictionary<Type, Lazy<IStringParser>>();

            var ispi = typeof(IStringParser);

            var types = ReflectionUtility.AllTypes()
                .Where(t => t.GetDefaultConstructor() != null && t.HasInterface(ispi));
            foreach(var type in types)
            {
                var cnstrinfo = type.GetDefaultConstructor();
                var isp = (IStringParser)cnstrinfo.Invoke(Type.EmptyTypes);

                cache.TryAdd(isp.TargetType, new Lazy<IStringParser>(() => isp));
            }
        }

        public IStringParser GetStringParser(Type type)
        {
            var isp = GetStringParserInternal(type);
            if(isp != null)
            {
                return isp;
            }

            throw new Exception("TODO");
        }

        public IStringParser<T> GetStringParser<T>()
        {
            var type = typeof(T);

            var isp = GetStringParserInternal(type);
            if(isp != null)
            {
                return isp is IStringParser<T> ?
                    (IStringParser<T>)isp :
                    new StringParserImpl<T>(isp);
            }

            throw new Exception("TODO");
        }

        private IStringParser GetStringParserInternal(Type type)
        {
            Lazy<IStringParser> isp;
            if (cache.TryGetValue(type, out isp))
            {
                return isp.Value;
            }

            if (type.IsEnum)
            {
                return cache.GetOrAdd(
                    type,
                    key => new Lazy<IStringParser>(() => new EnumStringParser(type))
                    ).Value;
            }

            if (type.IsGenericType)
            {
                var utype = System.Nullable.GetUnderlyingType(type);
                if(utype != null)
                {
                    return cache.GetOrAdd(
                        type,
                        key => new Lazy<IStringParser>(() => new NullableStringParser(type, GetStringParser(utype)))
                        ).Value;
                }

                var cparser = GetStringParserIfCollection(type);
                if(cparser != null)
                {
                    return cache.GetOrAdd(
                        type,
                        key => new Lazy<IStringParser>(cparser)
                        ).Value;
                }
            }

            return null;
        }

        private Func<IStringParser> GetStringParserIfCollection(Type type)
        {
            var ttype = type.GetGenericTypeDefinition();

            if(ttype == typeof(List<>) || ttype == typeof(IList<>))
            {
                return () => new ListStringParser(
                    type, 
                    GetStringParser(type.GetGenericArguments()[0])
                    );
            }

            return null;
        }

        public IStringParser<DateTime> GetDateTimeParser(DateTimeFormatType formatType)
        {
            return GetDateTimeParser(formatType.GetValue());
        }

        public IStringParser<DateTime> GetDateTimeParser(string format)
        {
            return datetimecache.GetOrAdd(format, new Lazy<IStringParser<DateTime>>(() => new CustomFormatDateTimeStringParser(format))).Value;
        }

        public IStringParser<bool> GetBoolParser(BoolFormatType formatType)
        {
            return boolcache.GetOrAdd(formatType, new Lazy<IStringParser<bool>>(() =>
            {
                var tf = formatType.GetValue();
                return new CustomFormatBoolStringParser(tf.Item1, tf.Item2);
            })
            ).Value;
        }

        private class StringParserImpl<T> : IStringParser<T>
        {
            private IStringParser isp;

            public StringParserImpl(IStringParser isp)
            {
                this.isp = isp;
            }

            public Type TargetType
            {
                get
                {
                    return isp.GetType();
                }
            }

            public T ConvertFrom(string stringvalue)
            {
                return (T)isp.ConvertObjectFrom(stringvalue);
            }

            public object ConvertObjectFrom(string stringvalue)
            {
                return isp.ConvertObjectFrom(stringvalue);
            }

            public string ConvertObjectTo(object objectvalue)
            {
                return isp.ConvertObjectTo(objectvalue);
            }

            public string ConvertTo(T objectvalue)
            {
                return isp.ConvertObjectTo(objectvalue);
            }
        }
    }
}
