using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int FlightId { get; set; }
        public int SeatClassId { get; set; }
        public int SeatNumber { get; set; }
        public int BaggageNumber { get; set; }
        public int StatusId { get; set; }

        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
        public SeatClass SeatClass { get; set; }
        public BookingStatus Status { get; set; }
        public Payment Payment { get; set; }
    }
}