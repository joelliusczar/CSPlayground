using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;

namespace NinjaWeb
{
    public class EnchantmentModule: NinjectModule 
    {
        public override void Load()
        {
            Bind<ISay>().To<SayHola>();
        }
    }
}