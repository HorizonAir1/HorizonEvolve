using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicServices
    {
        public List<string> GetFlights(String Destinations)
        {
            Flight flight = new Flight();
            List<string> flights = new List<string>();
            foreach (var fli in flights)
            {
                flights.Add(fli);
            }

            return flights;
        }

        public static bool BookPassengers(int id, int passengerId, int flightId, int seatClassId, int seatNumber, int baggageCount, int bookingStatusId)
        {
            Booking addBooking = new Booking();
            {
                addBooking.Id = id;
                addBooking.PassengerId = passengerId;
                addBooking.FlightId = flightId;
                addBooking.SeatClassId = seatClassId;
                addBooking.SeatNumber = seatNumber;
                //addBooking.BaggageCount = baggageCount;
                //addBooking.BookingStatusId = bookingStatusId;
            }
            
            return true;
        }


    }
}
