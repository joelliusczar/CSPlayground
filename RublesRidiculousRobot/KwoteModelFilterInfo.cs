using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RublesRidiculousRobot
{
    public static class KwoteModelFilterInfo
    {

        public static IFilter Create(MootaDootaDefinishin md)
        {
            return Create(md, new IFilter[0]);
        }

        public static IFilter Create(MootaDootaDefinishin md,params IFilter[] additionalPhils)
        {
            List<IFilter> filters = new List<IFilter>(additionalPhils);

            filters.Add(KwoteModelFilterInfo.MagicFilter(md.MagicNumber));

            filters.Add(KwoteModelFilterInfo.DangerFilter(md.DangerNumber));

            return new MootaDootaFilterCollection(filters);
        }

        public static MetadataFilterInfo MagicFilter(int magicNumber)
        {
            return MetadataFilterInfo.Create<KwoteModel>(m => m.MagicNumber == magicNumber, "MagicNumber ==" + magicNumber);
        }

        public static MetadataFilterInfo DangerFilter(int dangerNumber)
        {
            return MetadataFilterInfo.Create<KwoteModel>(m => m.DangerNumber == dangerNumber, "DangerNumber == " + dangerNumber);
        }
    }
}
