using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class ProxyGenerator: IProxyGenerator
    {
        private readonly IProxyBuilder proxyBuilder;

        public ProxyGenerator(IProxyBuilder builder)
        {
            this.proxyBuilder = builder;
        }

        public ProxyGenerator()
            :this(new DefaultProxyBuilder())
        { }

        public object CreateInterfaceProxyWithoutTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy,
            ProxyGenerationOptions options,params IInterceptor[] interceptors)
        {
            if(interfaceToProxy == null)
            {
                throw new ArgumentNullException("interfaceToProxy");
            }
            if(interceptors == null)
            {
                throw new ArgumentNullException("interceptors");
            }

            if(!interfaceToProxy.GetType().IsInterface)
            {
                throw new ArgumentException("Specified type is not an interface","interfaceToProxy");
            }

            CheckNotGenericTypeDefinition(interfaceToProxy, "InterfaceToProxy");
            CheckNotGenericTypeDefinitions(additionalInterfacesToProxy, "additionalInterfacesToProxy");



        }

        protected Type CreateInterfaceProxyTypeWithoutTarget(Type interfaceToProxy,Type[] additionalInterfacesToProxy, ProxyGenerationOpions options)
        {

        }

        protected void CheckNotGenericTypeDefinition(Type type,string argumentName)
        {
            if(type != null && type.GetType().IsGenericTypeDefinition)
            {
                throw new Exception("can't create proxy for type because it is an open generic type");
            }
        }

        protected void CheckNotGenericTypeDefinitions(IEnumerable<Type> types, string argumentName)
        {
            if(types == null)
            {
                return;
            }
            foreach(Type t in types)
            {
                CheckNotGenericTypeDefinition(t, argumentName);
            }
        }
    }
}
