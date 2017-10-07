using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicService.Models
{
  public class SeatingModel
  {
    public int Seat_id { get; set; }
    public int Section { get; set; }
    public int Seat { get; set; }
    public int IsTaken { get; set; }
    public int Flight_id { get; set; }
  }
}