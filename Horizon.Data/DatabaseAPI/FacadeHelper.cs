using Database;
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
            return lf.addPassenger(passenger.Firstname,passenger.Lastname,passenger.Middle,passenger.Address,passenger.Birth_date,passenger.Email,passenger.Tel_num);
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
        public bool CancelFlight(PassengerModel passenger,FlightModel flight)
        {
            return lf.CancelFlight(passenger.passenger_id, flight.flight_id);
        }
        public bool ModifyFlight(PassengerModel passenger,FlightModel flight,BookingModel book)
        {
            return lf.ModifyFlight(passenger.passenger_id, flight.flight_id, book.seat_number);
        }
       
    }
}