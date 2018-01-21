using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fortress
{
    public static class MetaTypeElementUtil
    {
        public static string CreateNameForExplicitImplementation(Type sourceType, string name)
        {
            if(sourceType.GetTypeInfo().IsGenericType)
            {
                StringBuilder nameBuilder = new StringBuilder);
                nameBuilder.AppendNameOf(sourceType);
                nameBuilder.Append('.');
                nameBuilder.Append(name);
                return nameBuilder.ToString();
            }
            else
            {
                return string.Concat(sourceType.Name, ".", name);
            }
        }

        private static void AppendNameOf(this StringBuilder nameBuilder,Type type)
        {
            nameBuilder.Append(type.Name);
            if(type.GetTypeInfo().IsGenericType)
            {
                nameBuilder.Append('[');
                Type[] genericTypeArguments = type.GetGenericArguments();
                for(int i = 0, n = genericTypeArguments.Length; i < n; ++i)
                {
                    if(i > 0)
                    {
                        nameBuilder.Append(',');
                    }
                    nameBuilder.AppendNameOf(genericTypeArguments[i]);
                }
                nameBuilder.Append(']');
            }
        }
    }
}
