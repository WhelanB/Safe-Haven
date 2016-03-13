using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ABCSafeHaven.Models
{
    public class SafeHouse
    {
        public int ID { get; set; }
        [DisplayName("Contact:")]
        public String owner { get; set; }
        [DisplayName("Active")]
        public bool isAvailable { get; set; }
        [DisplayName("Capacity")]
        public int capacity { get; set; }
        [DisplayName("Address")]
        public String address { get; set; }
        [DisplayName("Requirements")]
        public String specialRequests { get; set; }



    }

    public class SafeHouseDBContext : DbContext
    {
        public DbSet<SafeHouse> SafeHouses { get; set; }
    }
}