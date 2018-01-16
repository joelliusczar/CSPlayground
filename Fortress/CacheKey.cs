using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fortress
{
    public class CacheKey
    {
        private readonly MemberInfo target;
        private readonly Type[] interfaces;
        private readonly ProxyGenerationOptions options;
        private readonly Type type;
        public CacheKey(MemberInfo target,Type type, Type[] interfaces, ProxyGenerationOptions options)
        {

        }
    }
}
