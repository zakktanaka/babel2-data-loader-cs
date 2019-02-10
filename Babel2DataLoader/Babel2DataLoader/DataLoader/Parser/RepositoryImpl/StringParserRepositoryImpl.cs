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
        private static ConcurrentDictionary<Type, IStringParser> cache;

        static StringParserRepositoryImpl()
        {
            cache = new ConcurrentDictionary<Type, IStringParser>();

            var ispi = typeof(IStringParser);

            var types = ReflectionUtility.AllTypes()
                .Where(t => t.GetDefaultConstructor() != null && t.HasInterface(ispi));
            foreach(var type in types)
            {
                var cnstrinfo = type.GetDefaultConstructor();
                var isp = (IStringParser)cnstrinfo.Invoke(Type.EmptyTypes);

                cache.TryAdd(isp.TargetType, isp);
            }

        }

        public IStringParser GetStringParser(Type type)
        {
            return cache[type];
        }

        public IStringParser<T> GetStringParser<T>()
        {
            return GetStringParser(typeof(T)) as IStringParser<T>;
        }
    }
}
