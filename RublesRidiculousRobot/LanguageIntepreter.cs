using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RublesRidiculousRobot
{
    /// <summary>
	/// Class which converts a single line of pseudo-code into something that will work
	/// in the filter by replacing unbound property references with calls to <see cref="ModelContext.Get{T}"/>.
	/// <example>
	/// <![CDATA[
	/// VehicleModel.Year > 0 && VehicleModel.Year < 1972      ->		return context.Get<VehicleModel>().Year > 0 && context.Get<VehicleModel>().Year < 1972;
	/// ]]>
	/// </example>
	/// </summary>
    public class LanguageIntepreter
    {
        private static readonly Dictionary<Regex, string> Replacements = new Dictionary<Regex, string>()
        {
            //(?<= |^|\()(?<model>[\w]+Model)(?=\.)"),"context.Get<${model}>()
            // replaces the first atom of each dotted expression with a call into the context to get a model of that type
            { new Regex(@"(?<= |^|\()(?<model>[\w]+Model)(?=\.)"),"context.Get<${model}>()" },
            { new Regex(@" and ")," && "},
            { new Regex(@" or "), " || "}
        };

        public string ConvertToCSharpMethodBody(string domainLanguage)
        {
            string methodBody = domainLanguage;
            foreach(KeyValuePair<Regex,string> replacement in Replacements)
            {
                methodBody = replacement.Key.Replace(methodBody, replacement.Value);
            }

            if(!methodBody.StartsWith("return"))
            {
                methodBody = "return " + methodBody;
            }

            if(!methodBody.EndsWith(";"))
            {
                methodBody = methodBody + ";";
            }

            return methodBody;
        }
    }

}
