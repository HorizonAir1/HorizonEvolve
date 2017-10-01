using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Booking : BaseModel<int>
    {
        //public int BookingId { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public int SeatClassId { get; set; }
        public int SeatNumber { get; set; }
        public int BaggageNumber { get; set; }
        public int StatusId { get; set; } //BookingStatusId

        //Navigation - Relationship Properties
        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
        public SeatClass SeatClass { get; set; }
        public BookingStatus Status { get; set; }
    }
}
