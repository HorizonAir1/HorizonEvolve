using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Database.Models
{
    public class Flight
    {
        public static bool createFlight(TimeSpan arrtime, DateTime arrdate, TimeSpan deptime, DateTime depdate, string dest, string dep, int craftid)
        {
            using (var db = new HorizonData())
            {
                DataAccess.Flight x = new DataAccess.Flight();
                x.arrival_time = arrtime;
                x.arrival_date = arrdate;
                x.depart_time = deptime;
                x.depart_date = depdate;
                x.destination = dest;
                x.departure = dep;
                x.aircraft_id = craftid;

                db.Flights.Add(x);
                db.SaveChanges();
                return true;
            }
        }
        public static bool updateFlight(int flightS, TimeSpan arrtime, DateTime arrdate, TimeSpan deptime, DateTime depdate, string dest, string dep, int craftid)
        {
            using (var db = new HorizonData())
            {
                DataAccess.Flight x = db.Flights.SingleOrDefault(i => i.flight_id == flightS);
                x.arrival_time = arrtime;
                x.arrival_date = arrdate;
                x.depart_time = deptime;
                x.depart_date = depdate;
                x.destination = dest;
                x.departure = dep;
                x.aircraft_id = craftid;

                db.Flights.Add(x);
                db.SaveChanges();
                return true;
            }
        }
        public static bool deleteFlight(int x)
            {
            using (var db = new HorizonData())
            {
                DataAccess.Flight t = db.Flights.SingleOrDefault(i => i.flight_id == x);
                db.Flights.Remove(t);
                db.SaveChanges();
                return true;
                

            }
            }
        public static bool BookPassenger(string passenger_email, int FlightId, int seatClass,  int seatNumber, int numBags)
    {
      using (var db = new HorizonData())
      {
        DataAccess.Passenger pass = db.Passengers.SingleOrDefault(p => p.email == passenger_email);
        DataAccess.Booking addB = new DataAccess.Booking()
        {
          passenger_id = pass.passenger_id,
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

    public static DataAccess.Flight GetFlight(int flightId)
    {
            using (var db = new HorizonData())
            {
                DataAccess.Flight x = db.Flights.SingleOrDefault(i => i.flight_id == flightId);
                return x;
                
            }
    }

    public static List<DataAccess.Flight> GetAllFlights(string startLoc, string destLoc, DateTime startSearch, DateTime endSearch, int numPassengers)
    {
      List<DataAccess.Flight> allFlights = new List<DataAccess.Flight>();
      using (var db = new HorizonData())
      {
        foreach (var item in db.Flights)
        {
          if ((item.departure==startLoc && item.destination==destLoc) &&
            (InBetween(startSearch,endSearch, item.depart_date, item.arrival_date)))
          {
            

            //add seating here;
            allFlights.Add(item);
          }
          
        }
        
      }
      return allFlights;
    }

    public static List<DataAccess.Flight> GetAllFlightDestinationsAndArrivals()
    {
      List<DataAccess.Flight> allDestAndDep = new List<DataAccess.Flight>();

      using (var db = new HorizonData())
      {
        foreach (var item in db.Flights)
        {
          if (!allDestAndDep.Contains(item))
            allDestAndDep.Add(item);
      
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

