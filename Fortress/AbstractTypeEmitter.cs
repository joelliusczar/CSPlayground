using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public abstract class AbstractTypeEmitter
    {
        private readonly IDictionary<string, FieldReference> fields = new Dictionary<string, FieldReference>(StringComparer.OrdinalIgnoreCase);

        public FieldReference GetField(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return null;
            }

            FieldReference value;
            fields.TryGetValue(name, out value);
            return value;
        }
    }
}
