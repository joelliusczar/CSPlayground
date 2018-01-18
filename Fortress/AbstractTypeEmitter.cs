using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Fortress
{
    public abstract class AbstractTypeEmitter
    {
        private readonly IDictionary<string, FieldReference> fields = new Dictionary<string, FieldReference>(StringComparer.OrdinalIgnoreCase);
        private TypeBuilder typeBuilder;

        public AbstractTypeEmitter(TypeBuilder typeBuilder)
        {
            this.typeBuilder = typeBuilder;
            //fill in
        }

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
