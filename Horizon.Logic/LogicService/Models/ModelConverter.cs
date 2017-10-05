using System;
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
        Email = pass.Email,
        Firstname = pass.FirstName,
        Middle = pass.Middle,
        Lastname = pass.LastName,
        BirthDate = pass.Birth_date,
        Address = pass.Address,
        PhoneNumber = pass.Tel_num
    }
  }
}