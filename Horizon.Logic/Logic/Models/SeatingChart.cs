using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class SeatingChart : BaseModel<int> 
    {
        //public int SeatId { get; set; }
        public int Section { get; set; }
        public int Seat { get; set; }
        public bool IsTaken { get; set; } //TODO: talk to Jaime
        public int FlightId { get; set; }
    }
}
