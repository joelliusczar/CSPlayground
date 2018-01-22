using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace Fortress
{
    public abstract class CompositeTypeContributor: ITypeContributor
    {
        protected readonly INamingScope namingScope;
        protected readonly ICollection<Type> interfaces = new HashSet<Type>();
        private readonly ICollection<MetaMethod> methods = new TypeElementCollection<MetaMethod>();
        private readonly ICollection<MetaEvent> events = new TypeElementCollection<MetaEvent>();

        protected CompositeTypeContributor(INamingScope namingScope)
        {
            this.namingScope = namingScope;
        }

        public void AddInterfaceToProxy(Type @interface)
        {
            Debug.Assert(@interface != null, "@interface shoudn't be null");
            Debug.Assert(@interface.GetTypeInfo().IsInterface, "@interface is supposed to be an interface");
            Debug.Assert(!this.interfaces.Contains(@interface), "our hashset doesn't have that interface");
            this.interfaces.Add(@interface);
        }

        public void CollectElementsToProxy(IProxyGenerationHook hook,MetaType model)
        {
            foreach(MembersCollector collector in this.CollectElementsToProxyInternal(hook))
            {
                foreach(MetaMethod method in collector.Methods)
                {
                    model.AddMethod(method);
                    this.methods.Add(method);
                }

                foreach(MetaEvent @event in collector.Events)
                {
                    model.AddEvent(@event);
                    this.events.Add(@event);
                }

            }
        }

        protected abstract IEnumerable<MembersCollector> CollectElementsToProxyInternal(IProxyGenerationHook hook);
    }
}
