using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class SeatClass : BaseModel<int>
    {
       // public int SeatClassId { get; set; }
        public string Desc { get; set; }
        public int PricingTier { get; set; }

        //Navigation - Relationship Properties
        public List<Booking> Bookings { get; set; }
    }
}
