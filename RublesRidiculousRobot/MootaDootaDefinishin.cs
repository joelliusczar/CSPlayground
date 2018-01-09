using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RublesRidiculousRobot
{
    public class MootaDootaDefinishin: IFilter
    {
        public int MagicNumber { get; set; }
        public int DangerNumber { get; set; }

        private MootaDootaFilterCollection _mdc;

        public MootaDootaFilterCollection bunchaMootaDootaFilter
        {
            get { return _mdc??(_mdc = new MootaDootaFilterCollection()); }
            set { _mdc = value; }
        }


        public bool Matches(ModelKontext kontext)
        {
            return bunchaMootaDootaFilter.Matches(kontext);
        }
    }
}
