using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Database;

namespace Logic.Services
{
    public class ClientServices : IClientService
    {
        private IUnitOfWork unitOfWork;

        public ClientServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Flight> GetAvailableFlightsWithDuration(string departLocation, string arrivalDestination, DateTime departDate, DateTime? returnDate = null)
        {
            IEnumerable<Flight> flights = new List<Flight>();

            flights = unitOfWork.Flights.GetAvailFlightsWithDuration(departLocation, arrivalDestination, departDate, returnDate);

            return flights;
        }

        public Flight GetFlightDetails(int flightId)
        {
            Flight flight = unitOfWork.Flights.GetWithDetails(flightId);

            return flight;
        }

        public void BookFlightWithSeat(int passengerId, int flightId, int seatId, int baggageCount, int seatClassId)
        {
            Booking booking = new Booking()
            {
                PassengerId = passengerId,
                FlightId = flightId,
                SeatNumber = seatId,
                BaggageNumber = baggageCount,
                SeatClassId = seatClassId,
                StatusId = 4
            };

            unitOfWork.Bookings.Add(booking);

            unitOfWork.Commit();
        }

        public IEnumerable<Booking> GetFutureBookings(int passengerId)
        {
            IEnumerable<Booking> bookings = unitOfWork.Bookings.GetFutureBookingsByPassenger(passengerId);

            return bookings;
        }

        public void CancelFlight(int bookingId)
        {
            Booking booking = unitOfWork.Bookings.Get(bookingId);

            booking.StatusId = 5;

            unitOfWork.Commit();
        }

        public void ChangeSeat(int bookingId, int newSeatId, int seatClassId)
        {
            Booking booking = unitOfWork.Bookings.Get(bookingId);

            booking.SeatNumber = newSeatId;
            booking.SeatClassId = seatClassId;

            unitOfWork.Commit();
        }

        public IEnumerable<SeatingChart> GetAvailableSeat(int flightId)
        {
            IEnumerable<SeatingChart> seats = unitOfWork.SeatingCharts.GetAvailableSeatsByFlight(flightId);

            return seats;
        }


        #region OldCode
        //public List<Flight> GetFlights(Flight flight)
        //{
        //    List<Flight> flights = new List<Flight>();
        //    foreach (var fli in flights)
        //    {
        //        fli.Id = flight.Id;
        //        fli.ArrivalTime = flight.ArrivalTime;
        //        fli.ArrivalDate = flight.ArrivalDate;
        //        fli.DepartTime = flight.DepartTime;
        //        fli.DepartDate = flight.DepartDate;
        //        fli.Destination = flight.Destination;
        //        fli.Departure = flight.Departure;
        //        fli.AircraftId = flight.AircraftId;
        //    }

        //    return flights;
        //}

        //public static bool bookPassenger(int passengerId, int flightID, int seatClassId, int seatNumber, int baggageCount, int bookingstatusId)
        //{
        //    Booking book = new Booking()
        //    {
        //        PassengerId = passengerId,
        //        FlightId = flightID,
        //        SeatClassId = seatClassId,
        //        SeatNumber = seatNumber,
        //        BaggageCount = baggageCount,
        //        BookingStatusId = bookingstatusId
        //    };

        //    return true;
        //}

        #endregion
    }
}
