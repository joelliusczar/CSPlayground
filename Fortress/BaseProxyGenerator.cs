using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class BaseProxyGenerator
    {
        protected readonly Type targetType;
        private ModuleScope scope;
        private ProxyGenerationOptions proxyGenerationOptions;


        protected ModuleScope Scope
        {
            get { return scope; }
        }

        protected ProxyGenerationOptions ProxyGenerationOptions
        {
            get
            {
                if(this.proxyGenerationOptions == null)
                {
                    throw new InvalidOperationException("ProxyGenerationOptions must be set");
                }

                return this.proxyGenerationOptions;
            }

            set
            {
                if(proxyGenerationOptions != null)
                {
                    throw new InvalidOperationException("ProxyGenerationOptions can only be set once.");
                }
                proxyGenerationOptions = value;
            }
        }

        protected BaseProxyGenerator(ModuleScope scope,Type targetType)
        {
            this.scope = scope;
            this.targetType = targetType;
        }

        protected void CheckNotGenericTypeDefinition(Type type,string argumentName)
        {
            if(type != null && type.IsGenericTypeDefinition)
            {
                throw new ArgumentException("type cannot be generic");
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

        protected Type GetFromCache(CacheKey key)
        {
            return this.Scope.GetFromCache(key);
        }

        protected void AddToCache(CacheKey key, Type type)
        {
            this.Scope.RegisterInCache(key, type);
        }

        protected Type ObtainProxyType(CacheKey cacheKey,Func<string,INamingScope,Type> factory)
        {
            Type cacheType;
            using (IUpgradeableLockHolder locker = this.Scope.Lock.ForReadingUpgradeable())
            {
                cacheType = this.GetFromCache(cacheKey);
                if(cacheType != null)
                {
                    return cacheType;
                }
                //Method: Ensure Equals and HashCode are overriden Accepts ProxyGenerationOptions
                string name = this.Scope.NamingScope.GetUniqueName("Fortress.Proxies." + this.targetType.Name + "Proxy");
                Type proxyType =  factory(name, this.Scope.NamingScope.SafeSubScope());

                locker.Upgrade();
                this.AddToCache(cacheKey, proxyType);
                return proxyType;
            }
        }

        protected void AddMappingNoCheck(Type @interface, ITypeContributor implementer, IDictionary<Type,ITypeContributor> mapping)
        {
            mapping.Add(@interface, implementer);
        }

        protected void AddMapping(Type @interface, ITypeContributor implementer, IDictionary<Type,ITypeContributor> mapping)
        {
            if(!mapping.ContainsKey(@interface))
            {
                this.AddMappingNoCheck(@interface, implementer, mapping);
            }
        }

    }
}
