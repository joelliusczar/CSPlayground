using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fortress
{
    public class MetaType
    {
        private readonly ICollection<MetaMethod> methods = new TypeElementCollection<MetaMethod>();
        private readonly ICollection<MetaEvent> events = new TypeElementCollection<MetaEvent>();
        private readonly ICollection<MetaProperty> properties = new TypeElementCollection<MetaProperty>();

        public IEnumerable<MetaMethod> Methods
        {
            get { return methods; } //Note: should be readonly
        }

        public void AddMethod(MetaMethod method)
        {
            this.methods.Add(method);
        }

        public void AddEvent(MetaEvent @event)
        {
            this.events.Add(@event);
        }

        public void AddProperty(MetaProperty property)
        {
            properties.Add(property);
        }
    }
}
