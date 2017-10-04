using Logic.Database;
using Logic.Database.Repositories;
using Logic.Repos;
using System.Collections.Generic;

namespace Logic
{
    public class UnitOfWork : IUnitOfWork
    {
        private List<FlightRepository> flights = new List<FlightRepository>();

        public UnitOfWork(FlightRepository flightRepository, PassengerRepository passengerRepository, BookingRepository bookingRepository)
        {
            Aircrafts = new AircraftRepository(context);
            Bookings = new BookingRepository(bookingRepository);
            BookingStatuses = new BookingStatusRepository(context);
            Flights = new FlightRepository();
            Passengers = new PassengerRepository(context);
            Payments = new PaymentRepository(context);
            SeatClasses = new SeatClassRepository(context);
            SeatingCharts = new SeatingChartRepository(context);

            Flights = flight;
        }

        public IAircraftRepository Aircrafts { get; set; }

        public IBookingRepository Bookings { get; set; }

        public IBookingStatusRepository BookingStatuses { get; set; }

        public IFlightRepository Flights { get; set; }

        public IPassengerRepository Passengers { get; set; }

        public IPaymentRepository Payments { get; set; }

        public ISeatClassRepository SeatClasses { get; set; }

        public ISeatingChartRepository SeatingCharts { get; set; }


        public void Commit()
        {
            flights.Add(Flights);
        }
    }
}
