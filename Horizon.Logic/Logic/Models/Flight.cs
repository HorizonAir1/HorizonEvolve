using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public TimeSpan DepartTime { get; set; }
        public DateTime DepartDate { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public int AircraftId { get; set; }
    }
}
