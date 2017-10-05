using Logic.Repos;
using LogicService.Controllers.Handler;
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
    private DataAPIHandler _dah;
    private Repos _repo;

    public BookingController() : base()
    {
      _dah = DataAPIHandler.Instance;
      _repo = Repos.Instance(_dah.GetTask("Passenger/"), _dah.GetTask("Booking/"), _dah.GetTask("Flight/"));
    }

    public HttpResponseMessage Get()
    {
      return Request.CreateResponse<List<BookingModel>>(HttpStatusCode.OK, ModelConverter.BookToModelList(_repo.GetAllBookings()));
    }

    public HttpResponseMessage Get(string email)
    {//get all bookings for passenger from repo
      if (_repo.CheckIfPassengerExist(email))
        return Request.CreateResponse<List<BookingModel>>(HttpStatusCode.OK, ModelConverter.BookToModelList(_repo.GetAllPassengerBookings(email)));
      return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "no such passenger");
    }

    

    public HttpResponseMessage Post(BookingModel booking)
    {//create new booking for passenger
      try
      {
        if (!_repo.CheckIfPassengerExist(booking.Email))
        {
          _repo.CreatePassenger<PassengerModel>()
        }
          if (_dah.Login())
          {
            Task<HttpResponseMessage> task = _dah.PostTask<PassengerModel>("Passenger/", passenger);
            _repo.CreatePassenger<HttpResponseMessage>(ModelConverter.ModelToPass(passenger), task);
            _dah.Logout();
            task.Wait();
            //return task.Result;
            if (task.Result.IsSuccessStatusCode)
              return Request.CreateResponse<string>(HttpStatusCode.OK, "passenger created");
            else return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "failed db save");
          }
          return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "Login Failed");

        
      }
      catch (Exception e)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
      }
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
