using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RublesRidiculousRobot
{

    public class KwoteModel
    {
        public int MagicNumber { get; set; }
        public int DangerNumber { get; set; }

        private SwordFightingModel _sw;

        public SwordFightingModel SwordFighting
        {
            get
            {
                if(_sw == null)
                {
                    _sw = new SwordFightingModel();
                }
                return _sw;
            }
            set { _sw = value; }
        }

        private MurderousSentientRollerCoasterModel _rc;

        public MurderousSentientRollerCoasterModel RollerCoaster
        {
            get
            {
                if(_rc == null)
                {
                    _rc = new MurderousSentientRollerCoasterModel();
                }
                return _rc;
            }
            set { _rc = value; }
        }

        private ExpiredGroundbeefTrebuchetModel _gb;

        public ExpiredGroundbeefTrebuchetModel Trebuchet
        {
            get
            {
                if(_gb == null)
                {
                    _gb = new ExpiredGroundbeefTrebuchetModel();
                }
                return _gb;
            }
            set { _gb = value; }
        }


    }

    public class SwordFightingModel
    {
        public string swordName { get; set; }
        public string fightingStyle { get; set; }
    }

    public class MurderousSentientRollerCoasterModel
    {
        public int VictimCount { get; set; }
        public double MurderSuccessRate { get; set; }
        public bool IsConfinedToRails { get; set; }
    }

    public class ExpiredGroundbeefTrebuchetModel
    {
        public int DaysExpired { get; set; }
        public bool CanTrebuchetAlsoLaunchPianos { get; set; }
        public string NameOfCowWhoDiedInVainDueToYourWastefulness { get; set; }

    }

    public enum LKRandom
    {
        unknown = 0,
        Magic = 1,
        Fish = 2,
        Coffee =3
    }
}
