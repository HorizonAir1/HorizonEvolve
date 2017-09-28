using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Database;
using DataAccess;

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
       Database.Flight.BookPassenger(1, 1, 1, 1, 1);

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
