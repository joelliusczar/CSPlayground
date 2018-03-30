using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autho.Models
{
    public class WhichSplatter
    {
        public string Name { get; set; }
        public int SplatD { get; set; }
        public SplatterPark PickedSplark { get; set; }
        public List<SplatterPark> SplatChoices { get; set; }

        public List<string> Mixins { get; set; }

        public List<bool> AreSplattered { get; set; }

    }
}