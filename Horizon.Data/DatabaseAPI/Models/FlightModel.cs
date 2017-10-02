﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseAPI.Models
{
    public class FlightModel
    {
        public int flight_id { get; set; }
        public DateTime arrival_time { get; set; }
        public string destination { get; set; }
        public string departure { get; set; }
        public int aircraft_id { get; set; }

    }
}