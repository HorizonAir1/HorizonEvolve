﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic.Models;

namespace LogicService.Models
{
  public class ModelConverter
  {
    public static PassengerModel PassToModel(Passenger pass)
    {
      return new PassengerModel
      {
        Email = pass.Email,
        Firstname = pass.FirstName,
        Middle = pass.Middle,
        Lastname = pass.LastName,
        Birth_date = pass.BirthDate,
        Address = pass.Address,
        Tel_num = pass.PhoneNumber
      };
    }

    public static Passenger ModelToPass(PassengerModel pass)
    {
      return new Passenger
      {
        Email = pass.Email,
        FirstName = pass.Firstname,
        Middle = pass.Middle,
        LastName = pass.Lastname,
        BirthDate = pass.Birth_date,
        Address = pass.Address,
        PhoneNumber = pass.Tel_num
      };
    }

    public static BookingModel BookToModel(Booking book)
    {
      return new BookingModel
      {
        passenger_email = book.Passenger.Email,
        booking_id = book.Id,
        flight_id = book.FlightId,
        seatclass_id = book.SeatClassId,
        seat_number = book.SeatNumber,
        baggage_num = book.BaggageNumber,
        status_id = book.StatusId
      };
    }

    public static List<BookingModel> BookToModelList(IEnumerable<Booking> bList)
    {
      List<BookingModel> mList = new List<BookingModel>();
      foreach (var item in bList)
      {
        mList.Add(BookToModel(item));
      }
      return mList;
    }

    public static Booking ModelToBook(BookingModel bModel, int passengerId)
    {
      return new Booking
      {
        PassengerId = passengerId
      };
    }

    public static Flight ModelToFlight(FlightModel flight)
    {
      return new Flight()
      {
        FlightId = flight.Flight_id,
        ArrivalTime = flight.Arrival_time,
        ArrivalDate = flight.Arrival_date,
        DepartTime = flight.Depart_time,
        DepartDate = flight.Depart_date,
        Destination = flight.Destination,
        Departure = flight.Departure,
        AircraftId = flight.Aircraft_id
      };
    }

    public static FlightModel FlightToModel(Flight flight)
    {
      return new FlightModel()
      {
        Flight_id = flight.FlightId,
        Arrival_time = flight.ArrivalTime,
        Arrival_date = flight.ArrivalDate,
        Depart_time = flight.DepartTime,
        Depart_date = flight.DepartDate,
        Destination = flight.Destination,
        Departure = flight.Departure,
        Aircraft_id = flight.AircraftId
      };
    }

    public static List<FlightModel> FlightToModelList(List<Flight> flights)
    {
      List<FlightModel> fmlist = new List<FlightModel>();
      foreach (var flight in flights)
      {
        fmlist.Add(FlightToModel(flight));
      }

      return fmlist;
    }
  }
}