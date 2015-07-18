using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenStreetMap.Models
{
    public class NominatimResponseAddress
    {   /// <summary>
        /// Model pro deserializaci dat z Nonimatimu
        /// </summary>

        public string road { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string house_number { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }

    }
}