using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlayground
{
    public class NumTwo
    {
        public int NumberOfHisName { get; set; }
        public string HisName { get; set; }
        public int HisFavoriteNumber { get; set; } = PlaygroundHelpers.CalculateNumTwosFavNum();
    }
}
