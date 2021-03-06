﻿using Database;
using Database.Models;
using DatabaseAPI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseAPI
{
  public class FacadeHelper
  {
    private static FacadeHelper _instance;
    private LogicFacade lf;


    private FacadeHelper()
    {
      lf = new LogicFacade();
    }

    public static FacadeHelper Instance
    {
      get
      {
        if (_instance == null) _instance = new FacadeHelper();
        return _instance;
      }
    }
    public bool CreatePassenger(PassengerModel passenger)
    {
      return lf.addPassenger(passenger.Firstname, passenger.Lastname, passenger.Middle, passenger.Address, passenger.Birth_date, passenger.Email, passenger.Tel_num);
    }

    public PassengerModel GetPassenger(PassengerModel passenger)
    {
      var x = lf.getPassenger(passenger.Email);
      passenger.Firstname = x.firstname;
      passenger.Middle = x.middle;
      passenger.Lastname = x.lastname;
      passenger.Birth_date = x.birth_date;
      passenger.Address = x.address;
      passenger.Tel_num = x.tel_num;
      return passenger;
    }


    public bool UpdatePassenger(PassengerModel passenger)
    {
      return lf.UpdatePassenger(passenger.Firstname, passenger.Lastname, passenger.Middle, passenger.Address, passenger.Birth_date, passenger.Email, passenger.Tel_num);
    }
    public bool CancelFlight(PassengerModel passenger, FlightModel flight)
    {
      return lf.CancelFlight(passenger.passenger_id, flight.flight_id);
    }
    public bool ModifyFlight(PassengerModel passenger, FlightModel flight, BookingModel book)
    {
      return lf.ModifyFlight(passenger.passenger_id, flight.flight_id, book.seat_number);
    }
    public FlightModel GetFlight(FlightModel flight)
    {
      var x = lf.GetFlight(flight.flight_id);
      flight.aircraft_id = x.aircraft_id;
      flight.arrival_time = x.arrival_time;
      flight.departure = x.departure;
      flight.destination = x.destination;
      flight.flight_id = x.flight_id;
      return flight;

    }
    public bool CreateFlight(FlightModel flight)
    {
      return lf.CreateFlight(flight.arrival_time, flight.arrival_date, flight.depart_time, flight.depart_date, flight.destination, flight.departure, flight.aircraft_id);
    }
    public bool UpdateFlight(FlightModel flight)
    {
      return lf.UpdateFlight(flight.flight_id, flight.arrival_time, flight.arrival_date, flight.depart_time, flight.depart_date, flight.destination, flight.departure, flight.aircraft_id);
    }
    public bool DeleteFlight(FlightModel flight)
    {
      return lf.DeleteFlight(flight.flight_id);
    }

    public bool BookPassenger(BookingModel book)
    {
      return lf.BookPassenger(book.passenger_email, book.flight_id, book.seatclass_id, book.seat_number, book.baggage_num,book.status_id);

    }
    public List<DataAccess.Flight> GetAllFlightsDestinations()
    {
      return lf.GetAllFlightDestinations();
    }

    public List<DataAccess.Flight> getAllflights(Search s)
    {
      return lf.GetAllFlights(s.StartLoc, s.EndLoc, s.StartTime, s.EndTime, s.numPass);
    }

    public List<BookingModel> GetAllBookings()
    {
      List<BookingModel> bookings = new List<BookingModel>();
      foreach (var x in lf.GetAllBooking())
      {
        BookingModel book = new BookingModel()
        {
          baggage_num = x.baggage_num,
          booking_id = x.booking_id,
          flight_id = x.flight_id,
          seatclass_id = x.seatclass_id,
          seat_number = x.seat_number,
          status_id = x.status_id,
          passenger_email = x.Passenger.email
        };

      }
      return bookings;
    }
    public BookingModel GetBooking(BookingModel book)
    {
      var x = lf.getBook(book.booking_id);
      book.baggage_num = x.baggage_num;
      book.booking_id = x.booking_id;
      book.flight_id = x.flight_id;
      book.seatclass_id = x.seatclass_id;
      book.seat_number = x.seat_number;
      book.status_id = x.status_id;
      return book;

    }
    public bool updateBook(FlightModel flight, BookingModel book)
    {
      return lf.updateBook(book.booking_id, book.baggage_num, flight.flight_id, book.flight_id, book.seatclass_id, book.seat_number, book.status_id);
    }
    public bool deleteBook(BookingModel book)
    {
      return lf.deleteBook(book.booking_id);
    }

    public List<PassengerModel> GetAllPassengers()
    {
      List<PassengerModel> passlist = new List<PassengerModel>();
      foreach (var pass in lf.GetAllPassengers())
      {
        passlist.Add(new PassengerModel()
        {
          passenger_id = pass.passenger_id,
          Email = pass.email,
          Firstname = pass.firstname,
          Middle = pass.middle,
          Lastname = pass.lastname,
          Birth_date = pass.birth_date,
          Address = pass.address,
          Tel_num = pass.tel_num,
        });
      }
      return passlist;
    }

    public List<FlightModel> GetAllFlights()
    {
      List<FlightModel> modellist = new List<FlightModel>();
      foreach (var f in lf.GetAllFlights())
      {
        modellist.Add(new FlightModel()
        {
          flight_id = f.flight_id,
          arrival_time = f.arrival_time,
          arrival_date = f.arrival_date,
          depart_time = f.depart_time,
          depart_date = f.depart_date,
          destination = f.destination,
          departure = f.departure,
          aircraft_id = f.aircraft_id
        });
      }
      return modellist;
    }
  }
}