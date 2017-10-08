using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class BookingStatus
    {
        public int StatusId { get; set; }
        public string Status { get; set; }

        //Navigation - Relationship Properties
        public List<Booking> Bookings { get; set; }
    }
}