﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Flight : BaseModel<int>
    {
        public int FlightId { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TimeSpan DepartTime { get; set; }
        public DateTime DepartDate { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public int AircraftId { get; set; }

        //Navigation - Relationship Properties
        public List<Booking> Bookings { get; set; }
        public Aircraft Aircraft { get; set; }
        public List<SeatingChart> SeatingCharts { get; set; }
    }
}
