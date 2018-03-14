using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Modules;
using System.Web.Mvc;

namespace Autho.Services
{
    public class AuthoResolver: IDependencyResolver
    {
        public IKernel Kernel { get; set; }

        public AuthoResolver(params NinjectModule[] modules)
        {
            this.Kernel = new StandardKernel(modules);
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

    }
}