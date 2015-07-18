using OpenStreetMap.Models;
using OpenStreetMap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OpenStreetMap.Controllers
{
    public class NominatimReverseController : ApiController
    {
        [HttpPost]
        [Route("Api/Nominatim/Reverse/Query")]
        public HttpResponseMessage Query(CoordinateViewModel coordinates)
        {
            NominatimService nominatimService;
            if(coordinates == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Nebyli odeslány žádná data");
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                nominatimService = new NominatimService();
                if (!nominatimService.GetData(coordinates.Latitude, coordinates.Longitude))
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Na daných souřadnicích nebyla nalezena žádná adresa");
            }

            catch
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable, "Došlo k chybě při komunikaci s externí službou");
            }
                Address address = nominatimService.TransferData();
                address.Latitude = coordinates.Latitude;
                address.Longitude = coordinates.Longitude;
                address.Email = coordinates.Email;
                address.Id = Guid.NewGuid();
                try
                {
                    DbService dbservice = new DbService();
                    dbservice.WriteAddress(address);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Chyba při ukládání dat do databáze");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Data vloženy do databáze");
            

            
            
        }
        
    }
}
