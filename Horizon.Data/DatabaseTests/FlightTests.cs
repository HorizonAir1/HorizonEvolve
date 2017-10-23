using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Database;
using DataAccess;
using Database.Models;

namespace Horizon.Logic.Tests
{
  public class FlightTests
  {
    [Fact]
    public void BookTest()
    {
      int initcount = 0;
      using (var db = new HorizonData())
      {
        initcount = db.Bookings.Count();
      }
       //Database.Models.Flight.BookPassenger("mail", 1, 1, 1, 1);

      int aftercount = 0;
      using (var db = new HorizonData())
      {
        aftercount = db.Bookings.Count();
      }
      var actual = aftercount == initcount + 1;
      Assert.True(actual);

      //test booking for seats
    }

    [Fact]
    public void GetAllFlightsTest()
    {
      //add flight data
         
            using (var db = new HorizonData())
            {
                int c =  db.Flights.Count();
                List<string> s = new List<string>();
                DataAccess.Flight x = new DataAccess.Flight();
                db.Flights.Add(x);
                int cA = db.Flights.Count();
                foreach (var i in db.Flights)
                {
                    s.Add(string.Format("{0} {1}",i.flight_id,i.depart_date));
                    Console.WriteLine(string.Format("{0} {1}", i.flight_id, i.depart_date));
                }
               
            }
            
                //check flights to see if flight is in flights list
                Assert.True(true);
    }

    [Fact]
    public void GetDestsAndArrivalTests()
    {
      //add dest /arrival 
      //check dests and arrivals to see if dest is in 
      Assert.True(true);
    }
  }
}
