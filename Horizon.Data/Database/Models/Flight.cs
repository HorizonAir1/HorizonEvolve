using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Database
{
  public class Flight
  {
    public static bool BookPassenger(int passenger_id, int FlightId, int seatClass,  int seatNumber, int numBags)
    {
      using (var db = new HorizonData())
      {
        Booking addB = new Booking()
        {
          passenger_id = passenger_id,
          flight_id = FlightId,
          seatclass_id= seatClass,
          seat_number = seatNumber,
          baggage_num = numBags,
          status_id= 1,
        };
        db.Bookings.Add(addB);
        db.SaveChanges();
      }

      return true;
    }

    public static Flight GetFlight(string flightId)
    {
      throw new NotImplementedException();
    }

    public static List<List<string>> GetAllFlights(string startLoc, string destLoc, DateTime startSearch, DateTime endSearch, int numPassengers)
    {
      List<List<string>> allFlights = new List<List<string>>();
      using (var db = new HorizonData())
      {
        foreach (var item in db.Flights)
        {
          if ((item.departure==startLoc && item.destination==destLoc) &&
            (InBetween(startSearch,endSearch, item.depart_date, item.arrival_date)))
          {
            List<string> flight = new List<string>();
            flight.Add(item.flight_id.ToString());
            flight.Add(item.arrival_time.ToString());
            flight.Add(item.arrival_date.ToString());
            flight.Add(item.depart_date.ToString());
            flight.Add(item.depart_time.ToString());
            flight.Add(item.destination);
            flight.Add(item.departure);

            //add seating here;
            allFlights.Add(flight);
          }
          
        }
        
      }
      return allFlights;
    }

    public static List<string> GetAllFlightDestinationsAndArrivals()
    {
      List<string> allDestAndDep = new List<string>();

      using (var db = new HorizonData())
      {
        foreach (var item in db.Flights)
        {
          if (!allDestAndDep.Contains(item.destination))
            allDestAndDep.Add(item.destination);
          if (!allDestAndDep.Contains(item.departure))
            allDestAndDep.Add(item.departure);
        }
      }

      return allDestAndDep;
    }

    public List<string> GetAvailableSeats()
    {
      throw new NotImplementedException();
    }

    private static bool InBetween(DateTime startSearch, DateTime endSearch, DateTime depart_date, DateTime arrival_date)
    {
      if (DateTime.Compare(startSearch, arrival_date) > 0)
        return false;
      if (DateTime.Compare(endSearch, depart_date) < 0)
        return false;
      return true;
    }
  }
}

