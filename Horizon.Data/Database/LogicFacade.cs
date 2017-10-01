
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;


namespace Database
{
  public class LogicFacade
  {
    // PASSENGERS -- DONE
    public bool CancelFlight(int user, int flightId)
    {
      return Passenger.cancelFly(user, flightId);
    }

    public bool ModifyFlight(int user, int flightId, int seat)
    {
      return Passenger.modifyFly(user, flightId, seat);
    }
    //FLIGHTS 
    public DataAccess.Flight GetFlight(int flightid)
        {
            return Database.Models.Flight.GetFlight(flightid);
        }

    public bool BookPassenger(int passenger_id, int FlightId, int seatClass, int seatNumber, int numBags)
    {
      return Flight.BookPassenger(passenger_id, FlightId, seatClass, seatNumber, numBags);
    }

    public List<DataAccess.Flight> GetAllFlightDestinations()
    {
      return Flight.GetAllFlightDestinationsAndArrivals();
    }
    // CHECK
    public List<DataAccess.Flight> GetAllFlights(string startLoc, string destLoc, DateTime startSearch, DateTime endSearch, int numPassengers)
    {
      return Flight.GetAllFlights( startLoc,  destLoc,  startSearch,  endSearch,  numPassengers);
    }
    //BOOKING -- DONE
    public DataAccess.Booking getBook(int y)
     {
            return Booking.getBook(y);
     }
        public bool updateBook(int bookID, int bag, int flightID, int passID, int seatid, int seatnum, int stat)
        {
            return Booking.updateBook(bookID, bag, flightID, passID, seatid, seatnum, stat);

        }
     public bool deleteBook(int y)
        {
            return Booking.deleteBook(y);
        }
     // SEATS?

    }
}
