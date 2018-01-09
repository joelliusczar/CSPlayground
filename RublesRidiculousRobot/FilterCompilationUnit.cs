using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RublesRidiculousRobot
{
    public class FilterCompilationUnit: IFilter
    {
        public string OriginalPredicateText { get; set; }

        public IFilter CompiledPredicate { get; set; }

        public string  ClassName { get; set; }

        public string SourceCode { get; set; }

        public FilterCompilationUnit(string originalPredicateText,string className, string sourceCode, IFilter compiledPredicate)
        {
            CompiledPredicate = compiledPredicate;

            OriginalPredicateText = originalPredicateText;
            ClassName = className;
            SourceCode = sourceCode;
        }

        public bool Matches(ModelKontext kontext)
        {
            return CompiledPredicate.Matches(kontext);
        }
    }
}
