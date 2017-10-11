using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseAPI.Models
{
    public class FlightModel
    {
        public int flight_id { get; set; }
        public TimeSpan arrival_time { get; set; }
        public DateTime arrival_date { get; set; }
        public TimeSpan depart_time { get; set; }
        public DateTime depart_date { get; set; } 
        public string destination { get; set; }
        public string departure { get; set; }
        public int aircraft_id { get; set; }

  }
}