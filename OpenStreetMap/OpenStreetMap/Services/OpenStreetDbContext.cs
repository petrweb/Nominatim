using OpenStreetMap.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OpenStreetMap.Services
{
    public class OpenStreetDbContext : DbContext
    {
        public DbSet<Address> Adress { get; set; }
    }
}