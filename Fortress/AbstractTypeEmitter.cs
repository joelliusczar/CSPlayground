using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Reflection;

namespace Fortress
{
    public abstract class AbstractTypeEmitter
    {
        private readonly IDictionary<string, FieldReference> fields = new Dictionary<string, FieldReference>(StringComparer.OrdinalIgnoreCase);
        private TypeBuilder typeBuilder;

        public TypeBuilder TypeBuilder
        {
            get { return this.typeBuilder; }
        }

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

        public FieldReference CreateStaticField(string name, Type fieldType)
        {
            return this.CreateStaticField(name, fieldType, FieldAttributes.Private);
        }

        public FieldReference CreateStaticField(string name, Type fieldType, FieldAttributes atts)
        {
            atts |= FieldAttributes.Static;
            return this.CreateField(name, fieldType, atts);
        }

        public FieldReference CreateField(string name,Type fieldType)
        {
            return this.CreateField(name, fieldType, true);
        }

        public FieldReference CreateField(string name, Type fieldType,bool serializable)
        {
            FieldAttributes atts = FieldAttributes.Private;

            if(!serializable)
            {
                atts |= FieldAttributes.NotSerialized;
            }
            return CreateField(name, fieldType, atts);
        }

        public FieldReference CreateField(string name,Type fieldType, FieldAttributes atts)
        {
            FieldBuilder fieldBuilder = this.typeBuilder.DefineField(name, fieldType, atts);
            FieldReference reference = new FieldReference(fieldBuilder);
            this.fields[name] = reference;
            return reference;

        }

        public void AddCustomAttributes(ProxyGenerationOptions proxyGenerationOptions)
        {
            foreach(CustomAttributeInfo attribute in proxyGenerationOptions.AdditionalAttributes)
            {
                typeBuilder.SetCustomAttribute(attribute.Builder);
#if FEATURE_SERIALIZATION
#endif
            }
        } 



    }
}
