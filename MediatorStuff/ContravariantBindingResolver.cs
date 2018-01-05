using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorStuff
{
    using System.Reflection;
    using Ninject.Infrastructure;
    using Ninject.Components;
    using Ninject.Planning.Bindings;
    using Ninject.Planning.Bindings.Resolvers;

    public class ContravariantBindingResolver: NinjectComponent,IBindingResolver
    {
        public IEnumerable<IBinding> Resolve(Multimap<Type,IBinding> bindings, Type service)
        {
            if(service.IsGenericType)
            {
                Type genericType = service.GetGenericTypeDefinition();
                Type[] genArgs = genericType.GetGenericArguments();
                //if it is something like object<T> rather than object<T,Y>
                if(genArgs.Count() == 1 
                    && genArgs.Single().GenericParameterAttributes.HasFlag(GenericParameterAttributes.Contravariant))
                {
                    Type argument = service.GetGenericArguments().Single();
                    IEnumerable<IBinding> matches = bindings.Where(kvp => kvp.Key.IsGenericType
                    && kvp.Key.GetGenericTypeDefinition().Equals(genericType)
                    && kvp.Key.GetGenericArguments().Single() != argument
                    && kvp.Key.GetGenericArguments().Single().IsAssignableFrom(argument))
                    .SelectMany(kvp => kvp.Value);
                    return matches;
                }
            }
            return Enumerable.Empty<IBinding>();
        }
    }
}
