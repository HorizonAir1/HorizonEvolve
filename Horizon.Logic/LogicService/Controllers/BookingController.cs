using LogicService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogicService.Controllers
{
  [AllowAnonymous]
  public class BookingController : ApiController
  {
    private LogicHelper lh = LogicHelper.Instance;
 
    public HttpResponseMessage Get(string email)
    {//get all bookings for passenger from repo

      throw new NotImplementedException();
    }

    public HttpResponseMessage Post(BookingModel booking)
    {//create new booking for passenger
      //check repo(logic) to see if passenger can book

      //create new booking and save to both repo and database at the same time

      throw new NotImplementedException();
    }

    // PUT: api/Booking/5
    public HttpResponseMessage Put(BookingModel booking)
    {//update booking for passenger
      //check repo(logic) to see if passenger has booking

      //update repo and database at the same time


      throw new NotImplementedException();
    }

    // DELETE: api/Booking/5
    public HttpResponseMessage Delete(int bookingid)
    {//cancel booking for passenger
      //check repo(logic) to see if passenger has booking

      //delete from repo and database at the same time

      throw new NotImplementedException();
    }
  }
}
