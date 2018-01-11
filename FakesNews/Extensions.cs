using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace FakesNews
{
    public static class Extensions
    {
        public static void ThrowIfCantFake(this MemberExpression memberAccess)
        {
            if(memberAccess.Member is FieldInfo)
            {
                throw new NotSupportedException();
            }
        }

        public static bool CanBeFaked(this Type typeToFake)
        {
            return typeToFake.IsInterface|| typeToFake.IsAbstract || (typeToFake.IsClass && !typeToFake.IsSealed);
        }
    }
}
