using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public int SeatClassId { get; set; }
        public int SeatNumber { get; set; }
        public int BaggageCount { get; set; }
        public int BookingStatusId { get; set; }
    }
}
