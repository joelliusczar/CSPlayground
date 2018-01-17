using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fortress
{
    public class InterfaceProxyWithTargetGenerator: BaseProxyGenerator
    {
        public InterfaceProxyWithTargetGenerator(ModuleScope scope,Type @interface)
            :base(scope,@interface)
        {
            CheckNotGenericTypeDefinition(@interface, "@interface");
        }

        public Type GenerateCode(Type proxyTargetType, Type[] interfaces, ProxyGenerationOptions options)
        {
            options.Initialize();

            CheckNotGenericTypeDefinition(proxyTargetType, "proxyTargetType");
            CheckNotGenericTypeDefinitions(interfaces, "interface");
            EnsureValidBaseType(options.BaseTypeForInterfaceProxy);
            ProxyGenerationOptions = options;

            interfaces = TypeUtil.GetAllInterfaces(interfaces);
            CacheKey cacheKey = new CacheKey(proxyTargetType, this.targetType, interfaces, options);



        }

        private void EnsureValidBaseType(Type type)
        {
            if(type == null)
            {
                throw new ArgumentException("base type fro proxy is null");
            }

            if(!type.IsClass)
            {
                throw new ArgumentException("is not a class type");
            }

            if(type.IsSealed)
            {
                throw new ArgumentException("it is sealed");
            }

            ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);

            if(constructor == null || constructor.IsPrivate)
            {
                throw new ArgumentException("does not have accessible parameterless constructor");
            }
        }
    }
}
