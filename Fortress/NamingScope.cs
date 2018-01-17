using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class NamingScope: INamingScope
    {
        private readonly IDictionary<string, int> names = new Dictionary<string, int>();
        private readonly INamingScope parentScope;

        public NamingScope()
        { }

        private NamingScope(INamingScope parent)
        {
            this.parentScope = parent;
        }

        public string GetUniqueName(string suggestedName)
        {
            int counter;
            if(!this.names.TryGetValue(suggestedName, out counter))
            {
                this.names.Add(suggestedName, 0);
                return suggestedName;
            }

            counter++;
            this.names[suggestedName] = counter;
            return suggestedName + "_" + counter.ToString();
        }

        public INamingScope SafeSubScope()
        {
            return new NamingScope(this);
        }
    }
}
