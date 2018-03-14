using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autho.Models;

namespace Autho.Services
{
    public interface IShipProvider
    {
        IEnumerable<Ship> GetShipsForPage(int pageNum);
        IEnumerable<Ship> GetAllShips();
    }
}
