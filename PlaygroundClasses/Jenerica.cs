using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundClasses
{
    public class JenericaSingular<TElement>
    {
        public List<TElement> elmList = new List<TElement>();

        public IEnumerable<TElement> GetNext()
        {
            foreach(TElement elm in elmList)
            {
                yield return elm;
            }
        }

        public void AddToList(TElement elm)
        {
            elmList.Add(elm);
        }
    }

    public class JenericaPluralis<TElement,TParm,TSult>: JenericaSingular<TElement>
    {
        public TSult RunFunc(Func<TParm,TSult> callMe,TParm p)
        {
            return callMe(p);
        }
    }
}
