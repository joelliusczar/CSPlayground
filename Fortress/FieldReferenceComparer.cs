using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    public class FieldReferenceComparer: IComparer<Type>
    {
        public int Compare(Type x,Type y)
        {
            if(x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }

            if(y == null)
            {
                throw new ArgumentNullException(nameof(y));
            }

            return string.CompareOrdinal(x.FullName, y.FullName);
        }
    }
}
