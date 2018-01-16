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

    }
}
