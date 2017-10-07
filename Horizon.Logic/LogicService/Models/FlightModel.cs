using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicService.Models
{
  public class FlightModel
  {
    public int Flight_id { get; set; }
    public System.TimeSpan Arrival_time { get; set; }
    public System.DateTime Arrival_date { get; set; }
    public System.TimeSpan Depart_time { get; set; }
    public System.DateTime Depart_date { get; set; }
    public string Destination { get; set; }
    public string Departure { get; set; }
    public int Aircraft_id { get; set; }
  }
}