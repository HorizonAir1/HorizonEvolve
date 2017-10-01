using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class BookingStatus : BaseModel<int>
    {
        //public int StatusId { get; set; }
        public string Status { get; set; }

        //Navigation - Relationship Properties
        public List<Booking> Bookings { get; set; }
    }
}
