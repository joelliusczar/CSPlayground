using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RublesRidiculousRobot
{
    public interface IFilter
    {
        bool Matches(ModelKontext kontext);
    }
}
