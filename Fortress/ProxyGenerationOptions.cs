using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fortress
{
    public class ProxyGenerationOptions
    {
        private List<object> mixins;
        private MixinData mixinData;
        private IList<CustomAttributeInfo> additionalAttributes = new List<CustomAttributeInfo>(); 

        public Type BaseTypeForInterfaceProxy { get; set; }
        public IProxyGenerationHook Hook { get; set; }

        public IInterceptorSelector Selector { get; set; }

        public bool HasMixins
        {
            get { return mixins != null && mixins.Count != 0; }
        }

        public IList<CustomAttributeInfo> AdditionalAttributes
        {
            get { return this.additionalAttributes; }
        }

        public MixinData MixinData
        {
            get
            {
                if(this.mixinData == null)
                {
                    throw new InvalidOperationException("There is no mixin data! call Initialize first");
                }
                return this.mixinData;
            }
        }

        public ProxyGenerationOptions(IProxyGenerationHook hook)
        {
            this.BaseTypeForInterfaceProxy = typeof(object);
            this.Hook = hook;
        }

        public ProxyGenerationOptions()
            :this(new AllMethodsHook())
        { }

        public void Initialize()
        {
            //when is mixins initialized?
            if(mixinData == null)
            {
                try
                {
                    mixinData = new MixinData(mixins);
                }
                catch(ArgumentException ex)
                {
                    throw new ArgumentException("There is a problem with the mixins", ex);
                }
            }
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(this,obj))
            {
                return true;
            }

            ProxyGenerationOptions proxyGenOpts = obj as ProxyGenerationOptions;
            if(ReferenceEquals(proxyGenOpts,null))
            {
                return false;
            }

            this.Initialize();
            proxyGenOpts.Initialize();

            if(!Equals(this.Hook, proxyGenOpts.Hook))
            {
                return false;
            }
            if(!Equals(this.Selector == null,proxyGenOpts.Selector == null))
            {
                return false;
            }
            if(!Equals(this.MixinData, proxyGenOpts.MixinData))
            {
                return false;
            }
            if(!Equals(this.BaseTypeForInterfaceProxy,proxyGenOpts.BaseTypeForInterfaceProxy))
            {
                return false;
            }
            if(!CollectionExtensions.AreEquivalent(this.AdditionalAttributes,proxyGenOpts.AdditionalAttributes))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            this.Initialize();

            unchecked
            {
                int result = Hook != null ? Hook.GetType().GetHashCode() : 0;
                result = 29 * result + (this.Selector != null ? 1 : 0);
                result = 29 * result + this.MixinData.GetHashCode();
                result = 29 * result + (this.BaseTypeForInterfaceProxy != null?this.BaseTypeForInterfaceProxy.GetHashCode():0);
                result = 29 * result + CollectionExtensions.GetContentsHashCode(this.AdditionalAttributes);
                return result;
            }
        }
    }
}
