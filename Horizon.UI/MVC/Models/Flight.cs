using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public class Flight
    {
        public int Flight_id { get; set; }
        public TimeSpan Arrival_time { get; set; }
        public DateTime Arrival_date { get; set; }
        public TimeSpan Depart_time { get; set; }
        public DateTime Depart_date { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public int Aircraft_id { get; set; }
    }
}