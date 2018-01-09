using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;

namespace RublesRidiculousRobot
{
    public class DynamikKodeFaktory
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
        private static readonly string NameHouse= typeof(FilterCompilationUnit).Namespace;
        private static readonly string BaseClassName = typeof(DynamicFilterAbstractBase).FullName;
        private static readonly string ContextName = typeof(ModelKontext).FullName;

        private readonly Dictionary<string, FilterCompilationUnit> _filterCompiliationUnits = new Dictionary<string, FilterCompilationUnit>();
        private readonly Dictionary<string, IFilter> _compiledFilters = new Dictionary<string, IFilter>();

        private CombilationBatch _batch;

        public CombilationBatch batch
        {
            get
            {
                if(_batch == null)
                {
                    _batch = new CombilationBatch();
                }
                return _batch;
            }
            set { _batch = value; }
        }


        public IFilter Create(string predicateString, IEnumerable<Type> typesOfStuff = null, IEnumerable<string> namespacesToInclude = null)
        {
            return CompiledPredicateInfo(predicateString, typesOfStuff ?? Type.EmptyTypes, namespacesToInclude ?? Enumerable.Empty<string>());
        }


        public IFilter CompiledPredicateInfo(string predicatString,IEnumerable<Type> typesOfStuff, IEnumerable<string> namesSpacesToInclude)
        {

            batch.NamespacesBang.AddRange(namesSpacesToInclude);

            foreach(string assemblyName in typesOfStuff.Select(t => t.Assembly.Location))
            {
                batch.AssembliesBang.Add(assemblyName);
            }

            LanguageIntepreter interpreter = new LanguageIntepreter();

            string methodBody = interpreter.ConvertToCSharpMethodBody(predicatString);

            IEnumerable<string> requiredTypeNames = Regex.Matches(methodBody, "context.Get<([^>]*)>")
                .OfType<Match>()
                .Select(m => string.Format("typeof({0})", m.Groups[1].Value))
                .Distinct();

            string className = "DynamicPredicateExperiment";

            string sourceCode = string.Format(rubleClassTemplate,
                className,
                BaseClassName,
                string.Join(",",requiredTypeNames),
                ContextName,
                methodBody);

            batch.ClassCodeBang.Add(sourceCode);

            IFilter compilation = Resolve(className);

            FilterCompilationUnit unit = new FilterCompilationUnit(predicatString, className, sourceCode, compilation);

            _filterCompiliationUnits.Add(predicatString, unit);

            return unit;

        }

        public IFilter Resolve(string className)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("c#");
            CompilerParameters options = new CompilerParameters
            {
                GenerateInMemory = true,
                IncludeDebugInformation = true

            };

            foreach (string assemb in batch.AssembliesBang)
            {
                options.ReferencedAssemblies.Add(assemb);
            }

            string usings = string.Join("\n", batch.NamespacesBang.Select(n => string.Format("using {0};", n)));
            string classes = string.Join("\n\n", batch.ClassCodeBang);
            string sourceCode = string.Format(SourceCodeTemplate, NameHouse, usings, classes);

            CompilerResults results = provider.CompileAssemblyFromSource(options, sourceCode);


            foreach(Type tip in results.CompiledAssembly.GetExportedTypes().Where(t => typeof(IFilter).IsAssignableFrom(t)))
            {
                _compiledFilters.Add(tip.Name, (IFilter)Activator.CreateInstance(tip));
            }

            IFilter filter = null;
            _compiledFilters.TryGetValue(className, out filter);

            return filter;
        }







    }
}
