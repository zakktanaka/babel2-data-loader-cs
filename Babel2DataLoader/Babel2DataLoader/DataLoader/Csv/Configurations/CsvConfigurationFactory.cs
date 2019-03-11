using Babel2.DataLoader.Csv.TypeConvension;
using Babel2.DataLoader.Parser;
using Babel2.DataLoader.Utilities;
using CsvHelper.Configuration;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Babel2.DataLoader.Csv.Configurations
{
    class CsvConfigurationFactory
    {
        private IStringParserRepository parserRepository;
        private ITypeConverterRepository typeConverterRepository;

        public CsvConfigurationFactory(IStringParserRepository parserRepository, ITypeConverterRepository typeConverterRepository)
        {
            this.parserRepository = parserRepository;
            this.typeConverterRepository = typeConverterRepository;
        }

        public CsvConfiguration GetConfiguration<T>()
        {
            CheckValidType(typeof(T));

            var conf = new CsvConfiguration
            {
                CsvHelperConfiguration = new Configuration { }
            };

            conf.CsvHelperConfiguration.PrepareHeaderForMatch = (header, id) => header.Trim().ToLower();
            conf.CsvHelperConfiguration.RegisterClassMap(NewClassMap<T>());

            return conf;
        }

        private ClassMap<T> NewClassMap<T>()
        {
            var type = typeof(T);
            var cmap = new ClassMapImpl<T>();
            var obj = type.GetDefaultConstructor().Invoke(Type.EmptyTypes);
            foreach(var prop in type.GetProperties().Where(p => ShouldBeMember(p)))
            {
                var dm = prop.GetCustomAttribute<DataMemberAttribute>();
                var m = cmap.Map(type, prop)
                    .Name(dm.Name ?? prop.Name)
                    .Default(prop.GetValue(obj))
                    .TypeConverter(typeConverterRepository.GetTypeConverter(prop.PropertyType));
                if(dm.Order >= 0) { m.Index(dm.Order); }
            }

            return cmap;
        }

        private static void CheckValidType(Type type)
        {
            if (type.GetCustomAttributes(typeof(DataContractAttribute), false).Length == 0)
            {
                throw new Exception();
            }

            if (type.GetDefaultConstructor() == null)
            {
                throw new Exception();
            }
        }

        private static bool ShouldBeMember(PropertyInfo propertyinfo)
        {
            return
                propertyinfo.GetCustomAttribute<DataMemberAttribute>() != null &&
                propertyinfo.GetCustomAttribute<IgnoreDataMemberAttribute>() == null;
        }

        private class ClassMapImpl<T> : ClassMap<T>
        {
        }

    }
}
