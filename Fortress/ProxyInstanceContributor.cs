using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public abstract class ProxyInstanceContributor: ITypeContributor
    {
        protected readonly Type targetType;
        private readonly string proxyTypeId;
        private readonly Type[] interfaces;

        protected ProxyInstanceContributor(Type targetType, Type[] interfaces, string proxyTypeId)
    }
}
