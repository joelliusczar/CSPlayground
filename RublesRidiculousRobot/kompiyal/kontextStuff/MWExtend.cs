using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments.kompiyal.kontextStuff
{
    public static class MWExtend
    {
        public static IEnumerable<object> AsEnumerable(this IMerriamWebsterOfTypes instanseDiktionary)
        {
            return instanseDiktionary.Types.Select(t => instanseDiktionary[t]);
        }
    }
}
