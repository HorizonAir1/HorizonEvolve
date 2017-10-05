﻿using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repos
{
  public class Repos
  {
    private List<Booking> _bookings;

    private List<Passenger> _passengers;

    private List<Flight> _flights;

    private List<SeatingChart> _seats;

    private List<Aircraft> _aircrafts;

    private static Repos _instance;

    private Repos( List<Passenger> passengers, List<Flight> flights, List<Booking> bookings)
    {
      _passengers=passengers;
      _flights=flights;
      _bookings = bookings;
    }

    public static Repos Instance(Task<HttpResponseMessage> getPassengers, Task<HttpResponseMessage> getFlights, Task<HttpResponseMessage> getBookings)
    {

      if (_instance == null)
        {
          _instance = new Repos();
        }
        return _instance;
    }

    #region ClientCode
    public IEnumerable<Flight> GetAvailableFlightsWithDuration(string departLocation, string arrivalDestination, DateTime departDate, DateTime? returnDate = null)
    {
      List<Flight> flights = new List<Flight>();

      foreach (Flight fli in _flights)
      {
        if (fli.Departure == departLocation && fli.Destination == arrivalDestination && fli.DepartDate >= departDate && fli.ArrivalDate <= returnDate)
        {
        }
      }

      return null;
    }

    public Flight GetFlightDetails(int flightId)
    {
      foreach (var fli in _flights)
      {
        if (fli.Id == flightId)
        {
          return fli;
        }
      }

      return null;
    }

    public void BookFlightWithSeat(int passengerId, int flightId, int seatId, int baggageCount, int seatClassId)
    {
      foreach (var fli in _bookings)
      {
        if (fli.PassengerId == passengerId && fli.FlightId == flightId && fli.SeatNumber == seatId && fli.BaggageNumber == baggageCount && fli.SeatClassId == seatClassId)
        {
          _bookings.Add(new Booking()
          {
            PassengerId = passengerId,
            FlightId = flightId,
            SeatNumber = seatId,
            BaggageNumber = baggageCount,
            SeatClassId = seatClassId,
            StatusId = 4
          });
        }
      }
    }

    public IEnumerable<Booking> GetFutureBookings(int passengerId)
    {
      List<Booking> bookings = new List<Booking>();

      bookings = _bookings.Where(b => b.PassengerId == passengerId && b.Flight.DepartDate > DateTime.Now).ToList();

      return bookings;
    }

    public void CancelBooking(int bookingId)
    {
      Booking booking = _bookings.FirstOrDefault(b => b.Id == bookingId);

      if (booking != null)
      {
        booking.StatusId = 5;
      }
    }

    public void ChangeSeat(int bookingId, int newSeatId, int seatClassId)
    {
      Booking booking = _bookings.FirstOrDefault(b => b.Id == bookingId);

      if (booking != null)
      {
        booking.SeatNumber = newSeatId;
        booking.SeatClassId = seatClassId;
      }
    }

    public IEnumerable<SeatingChart> GetAvailableSeat(int flightId)
    {
      List<SeatingChart> availableSeats = _seats.Where(s => s.FlightId == flightId && !s.IsTaken).ToList();

      return availableSeats;
    }
    #endregion

    #region AdminCode
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

      _flights.Add(flight);

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

      _passengers.Add(passenger);

      return passenger;
    }

    public void EditCustomerPersonalInfo(int passengerId, string firstName, string middleName, string lastName, DateTime birthDate, string address, string phoneNumber, string email)
    {
      Passenger passenger = _passengers.FirstOrDefault(p => p.Id == passengerId);

      if (passenger != null)
      {
        passenger.FirstName = firstName;
        passenger.Middle = middleName;
        passenger.LastName = lastName;
        passenger.BirthDate = birthDate;
        passenger.Address = address;
        passenger.PhoneNumber = phoneNumber;
        passenger.Email = email;
      }
    }

    public void EditAircraftInfo(int aircraftId, string producer, int modelNumber, int seatActual, int seatMax)
    {
      Aircraft aircraft = _aircrafts.FirstOrDefault(a => a.Id == aircraftId);

      if (aircraft != null)
      {
        aircraft.Producer = producer;
        aircraft.ModelNumber = modelNumber;
        aircraft.SeatActual = seatActual;
        aircraft.SeatMax = seatMax;
      }
    }

    public void RemoveClientFromFlight(int passengerId, int flightId) //TODO: come back to this
    {
      Booking booking = _bookings.FirstOrDefault(b => b.FlightId == flightId && b.PassengerId == passengerId);

      if (booking != null)
      {
        _bookings.Remove(booking);
      }
    }

    public void EditCustomerBooking(int bookingId, int passengerId, int flightId, int seatClassId, int seatNumber, int baggageCount, int statusId)
    {
      Booking booking = _bookings.FirstOrDefault(b => b.PassengerId == passengerId);

      if (booking != null)
      {
        booking.PassengerId = passengerId;
        booking.FlightId = flightId;
        booking.SeatClassId = seatClassId;
        booking.SeatNumber = seatNumber;
        booking.BaggageNumber = baggageCount;
        booking.StatusId = statusId;
      }
    }

    public void CheckIfPassenger(string email, string firstName, string middleName, string lastName, DateTime birthDate, string address, string phoneNumber)
    {
      if (email != null)
      {
        CreatePassenger(firstName, middleName, lastName, birthDate, address, phoneNumber, email);
      }
    }
    #endregion
  }
}