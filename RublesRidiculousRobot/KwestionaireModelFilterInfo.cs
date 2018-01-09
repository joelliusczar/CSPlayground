using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RublesRidiculousRobot
{
    public static class KwestionaireModelFilterInfo
    {
        public static IFilter Create(MootaDootaDefinishin md)
        {
            List<IFilter> metadataFilters = new List<IFilter>()
            {
                MetadataFilterInfo.Create<int>(n => n == 1,"Section 1")
            };

            metadataFilters.Add(KwestionaireModelFilterInfo.MagicFilter(md.MagicNumber));

            metadataFilters.Add(KwestionaireModelFilterInfo.DangerFilter(md.DangerNumber));

            return new MootaDootaFilterCollection(metadataFilters);
        }

        public static MetadataFilterInfo MagicFilter(int magicNumber)
        {
            return MetadataFilterInfo.Create<KweschunareModel>(m => m.MagicNumber == magicNumber, "MagicNumber == " + magicNumber);
        }

        public static MetadataFilterInfo DangerFilter(int dangerNumber)
        {
            return MetadataFilterInfo.Create<KweschunareModel>(m => m.DangerNumber == dangerNumber, "DangerNumber == " + dangerNumber);
        }
    }
}
