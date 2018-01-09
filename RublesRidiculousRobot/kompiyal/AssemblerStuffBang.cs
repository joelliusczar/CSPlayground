using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Experiments.kompiyal
{
    public class AssemblerStuffBang
    {
        public HashSet<string> AssembliesBang { get; set; }
        public HashSet<string> NamespacesBang { get; set; }
        public HashSet<string> ClassCodeBang { get; set; }

        public AssemblerStuffBang()
        {
            AssembliesBang = new HashSet<string>()
            {
                Assembly.GetExecutingAssembly().Location
            };

            NamespacesBang = new HashSet<string>()
            {
                typeof(Type).Namespace,
            };

            ClassCodeBang = new HashSet<string>();
        }

    }
}
