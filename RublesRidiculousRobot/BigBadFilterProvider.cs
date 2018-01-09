using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RublesRidiculousRobot
{
    public class BigBadFilterProvider
    {
        public void CreateMetadataFiler(int sectionNumber,string filterString,MootaDootaDefinishin md)
        {

            DynamikKodeFaktory factory = new DynamikKodeFaktory();

            List<IFilter> metadataFilters = new List<IFilter>();
            if (sectionNumber == 0)
            {
                metadataFilters.Add(KwoteModelFilterInfo.Create(md));
            }
            else if (sectionNumber == 1)
            {
                metadataFilters.Add(KwestionaireModelFilterInfo.Create(md));
            }
            else
            {
                metadataFilters.Add(DefaultFilterStuff.Create(md));
            }

            IEnumerable<IFilter> dynamikFilters = filterString.Split(';')
                .Select(fs => factory.Create(fs, new[]
                {
                    typeof(KwoteModel),
                    typeof(KweschunareModel),
                },
                new[]
                {
                    typeof(KwoteModel).Namespace,
                    typeof(KweschunareModel).Namespace
                }));

            metadataFilters.AddRange(dynamikFilters);
        }
    }

    public static class DefaultFilterStuff
    {
        public static IFilter Create(MootaDootaDefinishin md)
        {
            List<IFilter> mdFilters = new List<IFilter>();

            mdFilters.Add(KwestionaireModelFilterInfo.MagicFilter(md.MagicNumber));

            mdFilters.Add(KwestionaireModelFilterInfo.DangerFilter(md.DangerNumber));

            return new MootaDootaFilterCollection(mdFilters);
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
