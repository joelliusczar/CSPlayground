using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Fortress
{
    public class MembersCollector
    {
        private readonly IDictionary<MethodInfo, MetaMethod> methods = new Dictionary<MethodInfo, MetaMethod>();
        private readonly IDictionary<EventInfo, MetaEvent> events = new Dictionary<EventInfo, MetaEvent>();
        private readonly IDictionary<PropertyInfo, MetaProperty> properties = new Dictionary<PropertyInfo, MetaProperty>();

        public IEnumerable<MetaMethod> Methods
        {
            get { return methods.Values; }
        }

        public IEnumerable<MetaEvent> Events
        {
            get { return events.Values; }
        }

        public IEnumerable<MetaProperty> Properties
        {
            get { return this.properties.Values; }
        }
    }
}
