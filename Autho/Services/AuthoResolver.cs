using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Modules;

namespace Autho.Services
{
    public class AuthoResolver
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

        public IEnumerable<object> GetAllServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

    }
}