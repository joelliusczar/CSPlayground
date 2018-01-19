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
        protected virtual bool AllowChangeTarget
        {
            get { return false; }
        }

        protected virtual string GeneratorType
        {
            get { return ProxyTypeConstants.InterfaceWithTarget; }
        }

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
            CacheKey cacheKey = new CacheKey(proxyTargetType.GetTypeInfo(), this.targetType, interfaces, options);



        }

        protected virtual Type GenerateType(string typeName, Type proxyTargetType, Type[] interfaces, INamingScope namingScope)
        {
            IEnumerable<ITypeContributor> contributors;
            IEnumerable<Type> allInterfaces = this.GetTypeImplimentingMapping(interfaces, proxyTargetType, out contributors, namingScope);

            ClassEmitter emitter;
            FieldReference interceptorsField;


        }

        protected virtual IEnumerable<Type> GetTypeImplimentingMapping(Type[] interfaces, Type proxyTargetType, 
            out IEnumerable<ITypeContributor> contributors, INamingScope namingScope)
        {
            IDictionary<Type, ITypeContributor> typeImplementerMapping = new Dictionary<Type, ITypeContributor>();
            MixinContributor mixins = new MixinContributor(namingScope, this.AllowChangeTarget);
            Type[] targetInterfaces = proxyTargetType.GetAllInterfaces();
            Type[] additionalInterfaces = TypeUtil.GetAllInterfaces(interfaces);
            ITypeContributor target = this.AddMappingForTargetType(typeImplementerMapping, proxyTargetType, targetInterfaces, additionalInterfaces, namingScope);

            if(this.ProxyGenerationOptions.HasMixins)
            {
                foreach(Type mixinInterface in this.ProxyGenerationOptions.MixinData.MixinInterfaces)
                {
                    if(targetInterfaces.Contains(mixinInterface))
                    {
                        if(additionalInterfaces.Contains(mixinInterface))
                        {
                            this.AddMapping(mixinInterface, target, typeImplementerMapping);
                        }

                        mixins.AddEmptyInterface(mixinInterface);
                    }
                    else
                    {
                        if(!typeImplementerMapping.ContainsKey(mixinInterface))
                        {
                            mixins.AddInterfaceToProxy(mixinInterface);
                            typeImplementerMapping.Add(mixinInterface, mixins);
                        }
                    }
                }
            }

            InterfaceProxyWithoutTargetContributor additionalInterfacesContributor = GetContributorForAdditionalInterfaces(namingScope);
            foreach(Type @interface in additionalInterfaces)
            {
                if(typeImplementerMapping.ContainsKey(@interface))
                {
                    continue;
                }
                if(this.ProxyGenerationOptions.MixinData.ContainsMixin(@interface))
                {
                    continue;
                }

                additionalInterfacesContributor.AddInterfaceToProxy(@interface);
                this.AddMappingNoCheck(@interface, additionalInterfacesContributor, typeImplementerMapping);
            }

            InterfaceProxyInstanceContributor instance = new InterfaceProxyInstanceContributor(targetType, this.GeneratorType, interfaces);
            try
            {
                this.AddMappingNoCheck(typeof(IProxyTargetAccessor),instance,typeImplementerMapping); 
            }
            catch(ArgumentException)
            {
                HandleExplicitlyPassedProxyTargetAccessor(targetInterfaces, additionalInterfaces);
            }

            contributors = new List<ITypeContributor>
            {
                target,
                additionalInterfacesContributor,
                mixins,
                instance
            };
            return typeImplementerMapping.Keys;

        }

        protected virtual Type Init(string typeName, out ClassEmitter emitter, Type proxyTargetType, out FieldReference interceptorField, IEnumerable<Type> interfaces)
        {
            Type baseType = this.ProxyGenerationOptions.BaseTypeForInterfaceProxy;

        }

        protected virtual InterfaceProxyWithoutTargetContributor GetContributorForAdditionalInterfaces(INamingScope namingScope)
        {
            return new InterfaceProxyWithoutTargetContributor(namingScope, (c, m) => NullExpression.Instance);
        }

        protected virtual ITypeContributor AddMappingForTargetType(IDictionary<Type,ITypeContributor> typeImplementerMapping, Type proxyTargetType, 
            ICollection<Type> targetInterfaces,ICollection<Type> additionalInterfaces,INamingScope namingScope)
        {
            InterfaceProxyTargetContributor contributor = new InterfaceProxyTargetContributor(proxyTargetType, this.AllowChangeTarget, namingScope);
            Type[] proxiedInterfaces = this.targetType.GetAllInterfaces();
            foreach(Type @interface in proxiedInterfaces)
            {
                contributor.AddInterfaceToProxy(@interface);
                this.AddMappingNoCheck(@interface, contributor, typeImplementerMapping);
            }

            return contributor;
        }

        private void EnsureValidBaseType(Type type)
        {
            if(type == null)
            {
                throw new ArgumentException("base type fro proxy is null");
            }

            if(!type.GetTypeInfo().IsClass)
            {
                throw new ArgumentException("is not a class type");
            }

            if(type.GetTypeInfo().IsSealed)
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
