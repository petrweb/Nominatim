using OpenStreetMap.Models;
using OpenStreetMap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OpenStreetMap.Controllers
{
    public class NominatimController : Controller
    {
        // GET: Nominatim
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult ShowHistory()
        {
            try
            {
                DbService DbService = new DbService();
                IEnumerable<Address> history = DbService.GetHistory();
                return View(history);
            }

            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Chyba při komunikaci s databází");
            }
           
        }
    }
}