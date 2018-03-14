using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autho.Models;
using Autho.Services;
using Newtonsoft.Json;

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


        public JsonResult GetJason(int? length,int? draw)
        {
            var ships = JsonConvert.SerializeObject(ShipProvider.GetAllShips());

            dynamic json = new
            {
                draw = draw ?? 0,
                recordsTotal = ShipProvider.GetAllShips().Count(),
                recordsFiltered = 10,
                data = ShipProvider.GetAllShips()
            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}