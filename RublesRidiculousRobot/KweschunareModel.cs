using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RublesRidiculousRobot
{
    public class KweschunareModel
    {
        public int MagicNumber { get; set; }
        public int DangerNumber { get; set; }


        private NinjasSteathilyPickingTheirNoseModel _nn;
        public NinjasSteathilyPickingTheirNoseModel NinjaNosePicker
        {
            get
            {
                if (_nn == null)
                {
                    _nn = new NinjasSteathilyPickingTheirNoseModel();
                }
                return _nn;
            }
            set
            {
                _nn = value;
            }
        }
        private SkyscrapersUsingTheirAntennasToSwordfightOtherSkyscapersModel _sk;
        public SkyscrapersUsingTheirAntennasToSwordfightOtherSkyscapersModel Skyscraper
        {
            get
            {
                if (_sk == null)
                {
                    _sk = new SkyscrapersUsingTheirAntennasToSwordfightOtherSkyscapersModel();
                }
                return _sk;
            }
            set
            {
                _sk = value;
            }
        }
        private PeopleWhoSuspectThatYoureTheOneWhoCloggedTheToiletAtTheNewYearsPartyModel _ct;
        public PeopleWhoSuspectThatYoureTheOneWhoCloggedTheToiletAtTheNewYearsPartyModel ToiletClogDetective
        {
            get
            {
                if (_ct == null)
                {
                    _ct = new PeopleWhoSuspectThatYoureTheOneWhoCloggedTheToiletAtTheNewYearsPartyModel();
                }
                return _ct;
            }
            set
            {
                _ct = value;
            }
        }
    }

    public class NinjasSteathilyPickingTheirNoseModel
    {
        public int NumberOfTimesCaught { get; set; }
        public bool WillNinjaKillYouIfYouCatchHimPickingHisNose { get; set; }
        public bool DoesNinjaHaveABloodyNose { get; set; }
    }

    public class SkyscrapersUsingTheirAntennasToSwordfightOtherSkyscapersModel
    {
        public string NameOfTower { get; set; }
        public SkyscrapersUsingTheirAntennasToSwordfightOtherSkyscapersModel RivalTower { get; set; }
        public int LengthOfSword { get; set; }
    }

    public class PeopleWhoSuspectThatYoureTheOneWhoCloggedTheToiletAtTheNewYearsPartyModel
    {
        public int SuspiciousGlancesPerMinute { get; set; }
        public string Name { get; set; }
        public bool DoTheyNowHaveToHoldTheirBowelsBecauseOfYou { get; set; }

    }
}
