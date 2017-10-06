﻿using Logic.Models;
using Newtonsoft.Json;
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

    private Repos(List<Passenger> passengers, List<Flight> flights, List<Booking> bookings)
    {
      _passengers = passengers;
      _flights = flights;
      _bookings = bookings;
    }

    public static Repos Instance(Task<HttpResponseMessage> getPassengers, Task<HttpResponseMessage> getFlights, Task<HttpResponseMessage> getBookings)
    {
      if (_instance == null)
      {
        getFlights.Start();
        getBookings.Start();

        var passengers = getPassengers.GetAwaiter().GetResult();
        List<Passenger> p;
        if (passengers.IsSuccessStatusCode)
        {
          var r = passengers.Content.ReadAsStringAsync().Result;
          p = JsonConvert.DeserializeObject<List<Passenger>>(r);
        }
        else return null;

        getFlights.Wait();
        var flights = getFlights.Result;
        List<Flight> f;
        if (flights.IsSuccessStatusCode)
        {
          var r = passengers.Content.ReadAsStringAsync().Result;
          f = JsonConvert.DeserializeObject<List<Flight>>(r);
        }
        else return null;

        getBookings.Wait();
        var bookings = getBookings.Result;
        List<Booking> b;
        if (passengers.IsSuccessStatusCode)
        {
          var r = passengers.Content.ReadAsStringAsync().Result;
          b = JsonConvert.DeserializeObject<List<Booking>>(r);
        }
        else return null;

        _instance = new Repos(p, f, b);
      }
      return _instance;
    }

    #region ClientCode
    public List<Flight> GetAvailableFlightsWithDuration(string departLocation, string arrivalDestination, DateTime departureDate, DateTime arriveDate)
    {
      List<Flight> flights = new List<Flight>();
      DateTime departDate = departureDate.Date;
      DateTime arrivalDate = arriveDate.Date;
      int numberOfdaysInFlight = (departDate - arrivalDate).Days;

      foreach (Flight fli in _flights)
      {
        if (fli.Departure == departLocation && fli.Destination == arrivalDestination)
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

    public List<Booking> GetAllBookings()
    {
      return _bookings;
    }

    public IEnumerable<Booking> GetAllPassengerBookings(string email)
    {
      List<Booking> bookings = bookings = _bookings.Where(b => b.Passenger.Email == email).ToList();
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

    public Passenger GetPassenger(string email)
    {
      Passenger passenger = _passengers.FirstOrDefault(p => p.Email == email);

      if (passenger != null)
      {
        return passenger;
      }

      return null;
    }
    #endregion

    #region AdminCode
    public void AddFlight<T>(Flight f, Task<T> task)
    {
      task.Start();
      Flight flight = new Flight()
      {
        ArrivalTime = f.ArrivalTime,
        ArrivalDate = f.ArrivalDate,
        DepartTime = f.DepartTime,
        DepartDate = f.DepartDate,
        Destination = f.Destination,
        Departure = f.Departure,
        AircraftId = f.AircraftId
      };

      _flights.Add(flight);
    }

    public void CreatePassenger<T>(Passenger p, Task<T> task)
    {
      task.Start();
      Passenger passenger = new Passenger()
      {
        FirstName = p.FirstName,
        Middle = p.Middle,
        LastName = p.LastName,
        BirthDate = p.BirthDate,
        Address = p.Address,
        PhoneNumber = p.PhoneNumber,
        Email = p.Email
      };

      _passengers.Add(passenger);
    }

    public void EditCustomerPersonalInfo<T>(Passenger update, Task<T> task)
    {
      task.Start();
      Passenger passenger = _passengers.FirstOrDefault(p => p.Email == update.Email);
      
      if (passenger != null)
      {
        passenger.FirstName = update.FirstName;
        passenger.Middle = update.Middle;
        passenger.LastName = update.LastName;
        passenger.BirthDate = update.BirthDate;
        passenger.Address = update.Address;
        passenger.PhoneNumber = update.PhoneNumber;
        passenger.Email = update.Email;
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

    public void RemoveClientFromFlight<T>(Booking book, Task<T> task)
    {
      task.Start();
      Booking booking = _bookings.FirstOrDefault(b => b.FlightId == book.FlightId && b.PassengerId == book.Passenger.Id);

      if (booking != null)
      {
        _bookings.Remove(booking);
      }
    }

    public void EditCustomerBooking<T>(Booking book, Task<T> task)
    {
      task.Start();
      Booking booking = _bookings.FirstOrDefault(b => b.Id== book.Id);

      if (booking != null)
      {
        booking.PassengerId = book.PassengerId;
        booking.FlightId = book.FlightId;
        booking.SeatClassId = book.SeatClassId;
        booking.SeatNumber = book.SeatNumber;
        booking.BaggageNumber = book.BaggageNumber;
        booking.StatusId = book.StatusId;
      }
    }

    public bool CheckIfPassengerExist(string email)
    {
      if (GetPassenger(email) == null)
      {
        return false;
      }

      return true;
    }
    #endregion
  }
}