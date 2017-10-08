using System.Collections.Generic;

namespace MVC.Models
{
    public class Aircraft
    {
        public string Producer { get; set; }
        public int ModelNumber { get; set; }
        public int SeatActual { get; set; }
        public int SeatMax { get; set; }

        public List<Flight> Flights { get; set; }
    }
}