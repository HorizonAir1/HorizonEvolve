using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicService.Models
{
  public class BookingModel : PassengerModel
  {
    public int booking_id { get; set; }
    public string passenger_email { get; set; }
    public int flight_id { get; set; }
    public int seatclass_id { get; set; }
    public int seat_number { get; set; }
    public int baggage_num { get; set; }
    public int status_id { get; set; }
    public PassengerModel passenger { get; set; }
  }
}