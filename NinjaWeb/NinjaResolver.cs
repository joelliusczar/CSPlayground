using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Modules;

namespace NinjaWeb
{
    public class NinjaResolver : IDependencyResolver
    {
        public IKernel Kernel { get; private set; }

        public NinjaResolver(params NinjectModule[] modules)
        {
            this.Kernel = new StandardKernel(modules);
        }

        public object GetService(Type serviceType)
        {
            return this.Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.Kernel.GetAll(serviceType);
        }
    }
}