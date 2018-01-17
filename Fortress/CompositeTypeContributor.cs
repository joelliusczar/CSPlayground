using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class CompositeTypeContributor: ITypeContributor
    {
        protected readonly INamingScope namingScope;
        protected readonly ICollection<Type> interfaces = new HashSet<Type>();

        protected CompositeTypeContributor(INamingScope namingScope)
        {
            this.namingScope = namingScope;
        }

        public void AddInterfaceToProxy(Type @interface)
        {
            this.interfaces.Add(@interface);
        }
    }
}
