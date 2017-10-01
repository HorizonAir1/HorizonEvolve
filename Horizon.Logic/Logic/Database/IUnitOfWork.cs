using Logic.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Database
{
    public interface IUnitOfWork
    {
        IAircraftRepository Aircrafts { get; set; }
        IBookingRepository Bookings { get; set; }
        IBookingStatusRepository BookingStatuses { get; set; }
        IFlightRepository Flights { get; set; }
        IPassengerRepository Passengers { get; set; }
        IPaymentRepository Payments { get; set; }
        ISeatClassRepository SeatClasses { get; set; }
        ISeatingChartRepository SeatingCharts { get; set; }

        void Commit();
    }
}
