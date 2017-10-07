using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseAPI.Models
{
    public class Search
    {
        public string StartLoc { get; set; }
        public string EndLoc { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int numPass { get; set; }
    }
}