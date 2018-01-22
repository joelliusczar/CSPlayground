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

        public IEnumerable<MetaMethod> Methods
        {
            get { return methods.Values; }
        }

        public IEnumerable<MetaEvent> Events
        {
            get { return events.Values; }
        }
    }
}
