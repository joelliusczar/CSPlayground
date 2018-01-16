using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakesNews
{
    public abstract class ProxyFactory
    {
        public static ProxyFactory Instance { get; } = new FortressProxyFactory();

        public abstract object CreateProxy(Type fakeType, IInterceptor interceptor, Type[] interfaces, object[] arguments);

    }
}
