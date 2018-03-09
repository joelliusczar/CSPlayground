using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Autho.Services;

namespace Autho.Services
{
    public class AuthoModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IShipProvider>().To<ShipProvider>();
        }
    }
}