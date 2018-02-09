using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

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
            if(type != null && type.GetTypeInfo().IsGenericTypeDefinition)
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

        protected void HandleExplicitlyPassedProxyTargetAccessor(ICollection<Type> targetInterfaces, ICollection<Type> additionalInterfaces)
        {
            //don't care

            string interfaceName = typeof(IProxyTargetAccessor).ToString();
            string message;
            if (targetInterfaces.Contains(typeof(IProxyTargetAccessor)))
            {
                message = string.Format("Are you trying to proxy an existing proxy?");
            }
            else if (this.ProxyGenerationOptions.MixinData.ContainsMixin(typeof(IProxyTargetAccessor)))
            {
                this.ProxyGenerationOptions.MixinData.GetMixinInstance(typeof(IProxyTargetAccessor));
            }
            else { }
        }

        protected void AddMappingNoCheck(Type @interface, ITypeContributor implementer, IDictionary<Type,ITypeContributor> mapping)
        {
            Debug.Assert(implementer != null, "implementer is null");
            Debug.Assert(@interface != null, "@interface is null");
            Debug.Assert(@interface.GetTypeInfo().IsInterface, "@interface.IsInterface");

            mapping.Add(@interface, implementer);
        }

        protected void AddMapping(Type @interface, ITypeContributor implementer, IDictionary<Type,ITypeContributor> mapping)
        {
            if(!mapping.ContainsKey(@interface))
            {
                this.AddMappingNoCheck(@interface, implementer, mapping);
            }
        }

        protected virtual ClassEmitter BuildClassEmitter(string typeName, Type parentType, IEnumerable<Type> interfaces)
        {
            CheckNotGenericTypeDefinition(parentType, nameof(parentType));
            CheckNotGenericTypeDefinitions(interfaces, nameof(interfaces));

            return new ClassEmitter(this.Scope,typeName,parentType,interfaces);
                
        }

        protected virtual void CreateFields(ClassEmitter emitter)
        {
            this.CreateOptionsField(emitter);
            this.CreateSelectorField(emitter);
            this.CreateInterceptorsField(emitter);
        }

        protected virtual void CreateTypeAttributes(ClassEmitter emitter)
        {
            emitter.AddCustomAttributes(this.ProxyGenerationOptions);

#if FEATURE_SERIALIZATION
#endif
        }

        protected FieldReference CreateOptionsField(ClassEmitter emitter)
        {
            return emitter.CreateStaticField("proxyGenerationOptions", typeof(ProxyGenerationOptions));

        }

        protected void CreateSelectorField(ClassEmitter emitter)
        {
            if(this.ProxyGenerationOptions.Selector == null)
            {
                return;
            }

            emitter.CreateField("__selector", typeof(IInterceptorSelector));
        }

        protected void CreateInterceptorsField(ClassEmitter emitter)
        {
            FieldReference interceptorsField = emitter.CreateField("__interceptors",typeof(IInterceptor[]));

            //serialization stuff
        }

        protected 

    }
}
