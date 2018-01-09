using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments.kompiyal.kontextStuff
{

    public interface IMerriamWebsterOfTypes
    {
        object this[Type type] { get; set; }

        IEnumerable<Type> Types { get; }
    }
}
