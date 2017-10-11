using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class SeatClass
    {
        public int SeatClassId { get; set; }
        public string Description { get; set; }
        public int PricingTier { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}