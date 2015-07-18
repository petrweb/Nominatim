using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenStreetMap.Models
{  /// <summary>
    /// ViewModel pro MVC a Model pro Entity Framework - výpis uložených adres
    /// </summary>
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name="Zeměpisná šířka")]
        public double Latitude { get; set; }
        [Display(Name = "Zeměpisná délka")]
        public double Longitude { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Město")]
        public string City { get; set; }
        [Display(Name = "Číslo popisné")]
        public string StreetNumber { get; set; }
        [Display(Name="PSČ")]
        public int PostalCode { get; set; }
         [Display(Name = "Země")]
        public string Country { get; set; }
    }
}