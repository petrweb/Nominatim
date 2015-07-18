using OpenStreetMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenStreetMap.Services
{
    /// <summary>
    /// Služba pro práci s databází.
    /// </summary>
    /// 
    public class DbService
    {
       
        private OpenStreetDbContext db = new OpenStreetDbContext();

        /// <summary>
        /// Získá všechny záznamy v databázi s historii hledání.
        /// </summary>
        /// 

        public IEnumerable<Address> GetHistory()
        {
            return db.Adress.ToList();
        }

        /// <summary>
        /// Vloží nový záznam o hledání do databáze.
        /// </summary>
        /// 

        public void WriteAddress(Address address)
        {
            db.Adress.Add(address);
            db.SaveChangesAsync();
        }
    }
}