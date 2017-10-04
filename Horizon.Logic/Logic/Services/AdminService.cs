using Logic.Database;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class AdminService : IAdminService
    {
        private IUnitOfWork unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Flight AddFlight(TimeSpan arrivalTime, DateTime arrivalDate, TimeSpan departureTime, DateTime departureDate, string destination, string departure, int aircraftId)
        {
            Flight flight = new Flight()
            {
                ArrivalTime = arrivalTime,
                ArrivalDate = arrivalDate,
                DepartTime = departureTime,
                DepartDate = departureDate,
                Destination = destination,
                Departure = departure,
                AircraftId = aircraftId
            };

            unitOfWork.Commit();
            return flight;
        }

        public Passenger CreatePassenger(string firstName, string middleName, string lastName, DateTime birthDate, string address, string phoneNumber, string email)
        {
            Passenger passenger = new Passenger()
            {
                FirstName = firstName,
                Middle = middleName,
                LastName = lastName,
                BirthDate = birthDate,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email
            };

            unitOfWork.Commit();
            return passenger;
        }

        public void EditCustomerPersonalInfo(int passengerId, string firstName, string middleName, string lastName, DateTime birthDate, string address, string phoneNumber, string email)
        {
            Passenger passenger = unitOfWork.Passengers.Get(passengerId);

            passenger.FirstName = firstName;
            passenger.Middle = middleName;
            passenger.LastName = lastName;
            passenger.BirthDate = birthDate;
            passenger.Address = address;
            passenger.PhoneNumber = phoneNumber;
            passenger.Email = email;

            unitOfWork.Commit();
        }

        public void EditAircraftInfo(int aircraftId, string producer, int modelNumber, int seatActual, int seatMax)
        {
            Aircraft aircraft = unitOfWork.Aircrafts.Get(aircraftId);

            aircraft.Producer = producer;
            aircraft.ModelNumber = modelNumber;
            aircraft.SeatActual = seatActual;
            aircraft.SeatMax = seatMax;

            unitOfWork.Commit();
        }

        public void RemoveClientFromFlight(int passengerId, int flightId) //TODO: come back to this
        {
            Flight flight = unitOfWork.Flights.Get(flightId);
            Passenger passenger = unitOfWork.Passengers.Get(passengerId);

            unitOfWork.Passengers.Remove(passenger);
            unitOfWork.Commit();
        }
    }
}
