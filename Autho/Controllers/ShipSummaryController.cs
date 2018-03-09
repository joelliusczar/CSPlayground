using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autho.Models;
using Autho.Services;

namespace Autho.Controllers
{
    public class ShipSummaryController : Controller
    {
        public IShipProvider ShipProvider { get; set; }
        public ShipSummaryController(IShipProvider shipProvider)
        {
            this.ShipProvider = shipProvider;
        }
        

        // GET: ShipSummary
        public ActionResult Index()
        {
            
            
            return View();
        }


    }
}