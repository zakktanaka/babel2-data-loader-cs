using Babel2.DataLoader.Parser.RepositoryImpl;
using Babel2.DataLoader.Utilities;
using System;
using System.Collections.Concurrent;

namespace Babel2.DataLoader.Parser
{
    public static class StringParserRepository
    {
        static StringParserRepository()
        {
            var cache = new ConcurrentDictionary<Type, Lazy<IStringParser>>();

            var ispi = typeof(IStringParser);

            var types = ReflectionUtility
                .AllTypesWhere(t => t.GetDefaultConstructor() != null && t.HasInterface(ispi));
            foreach (var type in types)
            {
                var cnstrinfo = type.GetDefaultConstructor();
                var isp = (IStringParser)cnstrinfo.Invoke(Type.EmptyTypes);

                cache.TryAdd(isp.TargetType, new Lazy<IStringParser>(() => isp));
            }

            DefaultRepository = new StringParserRepositoryImpl(cache);
        }

        public static IStringParserRepository DefaultRepository { get; }
    }
}
