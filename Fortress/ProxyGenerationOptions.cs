﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class ProxyGenerationOptions
    {
        private List<object> mixins;
        private MixinData mixinData;

        public Type BaseTypeForInterfaceProxy { get; set; }
        public IProxyGenerationHook Hook { get; set; }

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
    }
}