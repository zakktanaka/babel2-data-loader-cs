using Babel2.DataLoader.Parser.Enums;
using Babel2.DataLoader.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babel2.DataLoader.Parser.RepositoryImpl
{
    class StringParserRepositoryImpl : IStringParserRepository
    {
        private static ConcurrentDictionary<Type, Lazy<IStringParser>> cache;

        static StringParserRepositoryImpl()
        {
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

            return null;
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
