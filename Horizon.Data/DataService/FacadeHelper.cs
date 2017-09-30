using DataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataService
{
  public class FacadeHelper
  {
    private static FacadeHelper _instance;


    private FacadeHelper()
    {  
    }

    public static FacadeHelper Instance
    {
      get
      {
        if (_instance == null) _instance = new FacadeHelper();
        return _instance;
      }
    }

    public bool CreatePassenger(Passenger passenger)
    {
      return true;
    }

    public Passenger GetPassenger(Passenger passenger)
    {
      throw new NotImplementedException();
    }

    public bool RemovePassenger(Passenger passenger)
    {
      return true;
    }

    public bool UpdatePassenger(Passenger passenger)
    {
      return true;
    }

  }
}