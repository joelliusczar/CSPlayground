using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autho.Models;

namespace Autho.Services
{
    public class ShipProvider: IShipProvider
    {
        public IEnumerable<Ship> AllShips { get; set; }
        public const int RECORDS_PER_PAGE = 10;

        public ShipProvider()
        {
            this.AllShips = new List<Ship> {
                new Ship{name = "70006",CaptainName="Smith",NumCannons="2" },
                new Ship{name = "70007",CaptainName="Picard",NumCannons="3"},
                new Ship{name = "70008",CaptainName="Kirk",NumCannons="4" }
            };
        }

        public IEnumerable<Ship> GetShipsForPage(int pageNum)
        {
            int resultStart = RECORDS_PER_PAGE * pageNum;
            return AllShips.Skip(resultStart).Take(RECORDS_PER_PAGE);
        }

        public IEnumerable<Ship> GetAllShips()
        {
            return AllShips;
        }
    }
}