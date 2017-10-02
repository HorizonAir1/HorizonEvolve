
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using DataAccess;


namespace Database
{
    public class LogicFacade
    {
        // PASSENGERS -- DONE
        public bool CancelFlight(int user, int flightId)
        {
            return Models.Passenger.cancelFly(user, flightId);
        }

        public bool ModifyFlight(int user, int flightId, int seat)
        {
            return Models.Passenger.modifyFly(user, flightId, seat);
        }
        public bool addPassenger(string fname, string lname, string mname, string add, DateTime bdate, string email, string nums)
        {
            return Models.Passenger.addPassenger(fname, lname, mname, add, bdate, email, nums);
        }
        public bool UpdatePassenger(string fname, string lname, string mname, string add, DateTime bdate, string email, string nums)
        {
            return Models.Passenger.UpdatePassenger(fname, lname, mname, add, bdate, email, nums);
        }
        public DataAccess.Passenger getPassenger(string mail)
        {
            return Models.Passenger.GetPassenger(mail);
            
        }
        //FLIGHTS  
        public DataAccess.Flight GetFlight(int flightid)
        {
            return Database.Models.Flight.GetFlight(flightid);
        }

        public bool BookPassenger(string passenger_email, int FlightId, int seatClass, int seatNumber, int numBags)
        {
            return Models.Flight.BookPassenger(passenger_email, FlightId, seatClass, seatNumber, numBags);
        }

 
        public List<DataAccess.Flight> GetAllFlightDestinations()
        {
            return Models.Flight.GetAllFlightDestinationsAndArrivals();
        }
        // CHECK
        public List<DataAccess.Flight> GetAllFlights(string startLoc, string destLoc, DateTime startSearch, DateTime endSearch, int numPassengers)
        {
            return Models.Flight.GetAllFlights(startLoc, destLoc, startSearch, endSearch, numPassengers);
        }
        //BOOKING -- DONE
        public DataAccess.Booking getBook(int y)
        {
            return Models.Booking.getBook(y);
        }
        public bool updateBook(int bookID, int bag, int flightID, int passID, int seatid, int seatnum, int stat)
        {
            return Models.Booking.updateBook(bookID, bag, flightID, passID, seatid, seatnum, stat);

        }
        public bool deleteBook(int y)
        {
            return Models.Booking.deleteBook(y);
        }
        // SEATS?

    }
}
