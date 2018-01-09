using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RublesRidiculousRobot
{
    public class MootaDootaFilterCollection: IFilter
    {
        public IEnumerable<IFilter> Filters;

        public MootaDootaFilterCollection(params IFilter[] filters)
            :this(filters.AsEnumerable())
        { } 

        public MootaDootaFilterCollection(IEnumerable<IFilter> filters)
        {
            Filters = filters.SelectMany(mf =>
                {
                    MootaDootaFilterCollection collection = mf as MootaDootaFilterCollection;
                    if (collection != null) return collection.Filters;
                    return new[] { mf };
                }
            ).ToArray();
        }


        public bool Matches(ModelKontext kontext)
        {
            return Filters.Select(f => f.Matches(kontext))
                .DefaultIfEmpty(true)
                .Aggregate(true, (b1, b2) => b1 & b2);
        }
    }
}
