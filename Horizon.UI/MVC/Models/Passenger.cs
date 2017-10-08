using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Passenger
    {
        public int PassengerID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}