using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseAPI.Models
{
    public class PassengerModel
    {
        public int passenger_id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Middle { get; set; }
        public string Lastname { get; set; }
        public System.DateTime Birth_date { get; set; }
        public string Address { get; set; }
        public string Tel_num { get; set; }
    }
}