using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RublesRidiculousRobot
{
    class Program
    {
        /*
         * 
         * */
        static void Main(string[] args)
        {
            MootaDootaDefinishin md = new MootaDootaDefinishin();
            md.DangerNumber = 5;
            md.MagicNumber = 9;
            string filterString = "MurderousSentientRollerCoasterModel.IsConfinedToRails == false && MurderousSentientRollerCoasterModel.VictimCount > 0";
            BigBadFilterProvider bbfp = new BigBadFilterProvider();
            bbfp.CreateMetadataFiler(0, filterString, md);
        }
    }
}
