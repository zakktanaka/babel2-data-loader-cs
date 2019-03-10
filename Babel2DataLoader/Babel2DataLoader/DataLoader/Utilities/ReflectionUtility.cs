﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Babel2.DataLoader.Utilities
{
    static class ReflectionUtility
    {
        public static Type[] AllTypesWhere(Func<Type, bool> func)
        {
            var types = new List<Type>();

            foreach (var assambly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    types.AddRange(assambly.GetTypes().Where(func));
                }
                catch(Exception)
                {
                    // skip assembly.
                }
            }
            return types.ToArray();
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
