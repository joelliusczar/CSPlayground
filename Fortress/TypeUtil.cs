using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fortress
{
    public static class TypeUtil
    {
        public static Type[] GetAllInterfaces(this Type type)
        {
            return GetAllInterfaces(new[] { type });
        }

        public static Type[] GetAllInterfaces(params Type[] types)
        {
            if(types == null)
            {
                return Type.EmptyTypes;
            }

            HashSet<Type> interfaces = new HashSet<Type>();
            for(int i = 0;i < types.Length;i++)
            {
                Type t = types[i];
                if(t == null)
                {
                    continue;
                }

                if(t.IsInterface)
                {
                    if(interfaces.Add(t) == false)
                    {
                        continue;
                    }
                }

                Type[] innerInterfaces = t.GetInterfaces();
                for(int j = 0;j < innerInterfaces.Length;ji++)
                {
                    Type @interface = innerInterfaces[j];
                    interfaces.Add(@interface);
                }
            }

            return Sort(interfaces);
        }

        public static Type[] Sort(ICollection<Type> types)
        {
            Type[] array = new Type[types.Count];
            types.CopyTo(array, 0);
            Array.Sort(array, (l, r) => string.Compare(l.AssemblyQualifiedName, r.AssemblyQualifiedName, StringComparison.OrdinalIgnoreCase));

            return array;
        }
    }
}
