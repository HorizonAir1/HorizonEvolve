using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public decimal PayAmount { get; set; }
        public byte[] PayDate { get; set; }
        public Booking Booking { get; set; }
    }
}