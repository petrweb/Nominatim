using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;
using System.ComponentModel.DataAnnotations;
namespace OpenStreetMap.Models
{
    public class CoordinateViewModel
    {
        /// <summary>
        /// ViewModel pro zadávání dat určených k vyhledávání adres
        /// </summary>
        /// 

        [Required(ErrorMessage = "Údaj o zeměpisné šířce je povinný")]
        [Range(-90, 90, ErrorMessage="Neplatný údaj zeměpisné šířky")]
        [Display(Name = "Zeměpisná šířka")]
        public double Latitude { get; set; }
        [Range(-180, 180,ErrorMessage="Neplatný údaj zeměpisné délky")]
        [Required(ErrorMessage = "Údaj o zeměpisné délce je povinný")]
        [Display(Name = "Zeměpisná délka")]
        public double Longitude { get; set; }
        [Required(ErrorMessage = "Údaj o emailové adrese je povinný")]
        [EmailAddress(ErrorMessage="Emailová adresa není platná")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}