using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Fortress;

namespace FakesNews
{
    public class FortressProxyFactory: ProxyFactory
    {
        private ProxyGenerator generator;

        static FortressProxyFactory()
        {
            
        }

        public FortressProxyFactory()
        {
            this.generator = new ProxyGenerator();
        }

        public override object CreateProxy(Type fakeType, IInterceptor interceptor, Type[] interfaces, object[] arguments)
        {
            if(fakeType.GetTypeInfo().IsInterface)
            { }
        }
    }
}
