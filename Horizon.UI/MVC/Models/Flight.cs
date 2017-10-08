using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public TimeSpan MyProperty { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TimeSpan DepartTime { get; set; }
        public DateTime DepartDate { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public int AircraftId { get; set; }

        public List<Booking> Bookings { get; set; }
        public Aircraft Aircraft { get; set; }
        public List<SeatingChart> SeatingCharts { get; set; }
    }
}