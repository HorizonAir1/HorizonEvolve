using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface IClientService
    {
        IEnumerable<Flight> GetAvailableFlightsWithDuration(string departLocation, string arrivalDestination, DateTime departDate, DateTime? returnDate = null);
        Flight GetFlightDetails(int flightId);
        void BookFlightWithSeat(int passengerId, int flightId, int seatId, int baggageCount, int seatClassId);
        void CancelFlight(int bookingId);
        void ChangeSeat(int bookingId, int newSeatId, int seatClassId);
        IEnumerable<Booking> GetFutureBookings(int passengerId);
        IEnumerable<SeatingChart> GetAvailableSeat(int flightId);
    }
}
