using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Database;
using Logic.Models;

namespace Logic.Services
{
    public interface IAdminService 
    {
        Flight AddFlight(TimeSpan arrivalTime, DateTime arrivalDate, TimeSpan departureTime, DateTime departureDate, string destination, string departure, int aircraftId);
        Passenger CreatePassenger(string firstName, string middleName, string lastName, DateTime birthDate, string address, string phoneNumber, string email);
        void RemoveClientFromFlight(int passengerId, int flightId);
        void EditAircraftInfo(int aircraftId, string producer, int modelNumber, int seatActual, int seatMax);
        void EditCustomerPersonalInfo(int passengerId, string firstName, string middleName, string lastName, DateTime birthDate, string address, string phoneNumber, string email);
        void EditCustomerBooking(int bookingId, int passengerId, int flightId, int seatClassId, int seatNumber, int baggageCount, int statusId);
    }
}
