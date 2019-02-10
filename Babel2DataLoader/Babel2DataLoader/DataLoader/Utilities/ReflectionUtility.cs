using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Babel2.DataLoader.Utilities
{
    static class ReflectionUtility
    {
        public static IEnumerable<Type> AllTypes()
        {
            foreach(var assambly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach(var type in assambly.GetTypes())
                {
                    yield return type;
                }
            }
        }

        public static ConstructorInfo GetDefaultConstructor(this Type type)
        {
            return type.GetConstructor(Type.EmptyTypes);
        }

        public static bool HasInterface(this Type type, Type interfaceType)
        {
            return type.GetInterfaces().Any(i => i == interfaceType);
        }
    }
}
