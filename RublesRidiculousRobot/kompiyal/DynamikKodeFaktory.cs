using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;

namespace Experiments.kompiyal
{
    class DynamikKodeFaktory
    {

        private const string SourceCodeTemplate = @"
namespace {0}
{{
{1}

{2}
}}
";

        private const string rubleClassTemplate = @"
    public class {0} :{1}
    {{
        private static readonly Type[] _requiredTypes = new Type[] {{ {2} }};
        protected override Type[] RequiredTypes {{ get {{ return _requiredTypes; }} }}

        public override bool Matches({3} context)
        {{
            {4}
        }}
    }}
";

        private const string classTemplate = @"
    public class {0} : {1}
    {{
        {2}
    }}
";

        public void create()
        {
            AssemblerStuffBang bang = new AssemblerStuffBang();


            CodeDomProvider provider = CodeDomProvider.CreateProvider("c#");
            CompilerParameters options = new CompilerParameters
            {
                GenerateInMemory = true,
                IncludeDebugInformation = true

            };

            foreach(string assemb in bang.AssembliesBang)
            {
                options.ReferencedAssemblies.Add(assemb);
            }

            string usings = string.Join("\n", bang.NamespacesBang.Select(n => string.Format("using {0}", n)));
            string classes = string.Join("\n\n", bang.ClassCodeBang);


        }

        



    }
}
