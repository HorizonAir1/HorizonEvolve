
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;


namespace Database
{
  public class LogicFacade
  {
    public bool CancelFlight(int user, int flightId)
    {
      return Passenger.cancelFly(user, flightId);
    }

    public bool ModifyFlight(int user, int flightId, int seat)
    {
      return Passenger.modifyFly(user, flightId, seat);
    }

    public bool BookPassenger(int passenger_id, int FlightId, int seatClass, int seatNumber, int numBags)
    {
      return Flight.BookPassenger(passenger_id, FlightId, seatClass, seatNumber, numBags);
    }

    public List<string> GetAllFlightDestinations()
    {
      return Flight.GetAllFlightDestinationsAndArrivals();
    }

    public List<List<string>> GetAllFlights(string startLoc, string destLoc, DateTime startSearch, DateTime endSearch, int numPassengers)
    {
      return Flight.GetAllFlights( startLoc,  destLoc,  startSearch,  endSearch,  numPassengers);
    }
  }
}
