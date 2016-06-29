using Newtonsoft.Json;
using OpenStreetMap.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using OpenStreetMap.Infrastructure;
using System.Net;

namespace OpenStreetMap.Services
{
    /// <summary>
    /// Služba pro získávání dat z Nominatiumu
    /// </summary>
    public class NominatimService 
    {
     private   NominatimResponseRoot responseRoot;
     /// <summary>
     /// Metoda pro získávání dat z Nominatimu.
     /// </summary>
     public bool GetData(double Latitude, double Longitude)
     {
         HttpClient client = new HttpClient();
         client.BaseAddress = new Uri("http://nominatim.openstreetmap.org/");
         var response = client.GetAsync("reverse?lat=" + Latitude.ToStringWithADot() + "&lon=" + Longitude.ToStringWithADot() + "&format=json&addressdetails=1").Result;
         if (response.StatusCode == HttpStatusCode.NotFound)
             return false;
         else
         {
             responseRoot = JsonConvert.DeserializeObject<NominatimResponseRoot>(response.Content.ReadAsStringAsync().Result);
             return true;
         }
         client.Dispose();
     }
     /// <summary>
     /// Metoda pro mapování objektu získaného z Nominatimu na objekt Adress. Před užitím volejte metodu GetData();
     /// </summary>
      public Address TransferData()
      {

          if (responseRoot == null)
              throw new InvalidOperationException();
          NominatimResponseAddress nominatimResponseAddress = responseRoot.address;
          Address address = new Address();
          address.City = nominatimResponseAddress.city;
          if(nominatimResponseAddress.postcode != null)
          address.PostalCode = Int32.Parse(nominatimResponseAddress.postcode);
          address.StreetNumber = nominatimResponseAddress.house_number;
          address.Country = nominatimResponseAddress.country;
          return address;
      }
          

    }
}
