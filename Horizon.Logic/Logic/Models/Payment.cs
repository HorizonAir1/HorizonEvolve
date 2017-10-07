using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Payment : BaseModel<int>
    {
        //public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public decimal PayAmount { get; set; }
        public byte[] PayDate { get; set; }
        public Booking Booking { get; set; }
    }
}
