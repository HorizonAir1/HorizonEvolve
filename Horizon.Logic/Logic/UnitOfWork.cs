using Logic.Database;
using Logic.Database.Repositories;
using Database.Repositories;

namespace Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataSource context;

        public UnitOfWork(DataSource context)
        {
            Aircrafts = new AircraftRepository(context);
            Bookings = new BookingRepository(context);
            BookingStatuses = new BookingStatusRepository(context);
            Flights = new FlightRepository(context);
            Passengers = new PassengerRepository(context);
            Payments = new PaymentRepository(context);
            SeatClasses = new SeatClassRepository(context);
            SeatingCharts = new SeatingChartRepository(context);

            this.context = context;
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
            context.SaveChanges();
        }
    }
}
