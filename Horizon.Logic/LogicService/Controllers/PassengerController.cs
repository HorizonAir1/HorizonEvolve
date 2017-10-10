using LogicService.Controllers.Handler;
using LogicService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logic.Repos;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LogicService.Controllers
{
  [AllowAnonymous]
  public class PassengerController : ApiController
  {
    private DataAPIHandler _dah;
    private Repos _repo;

    public PassengerController() : base()
    {
      _dah = DataAPIHandler.Instance;
      if (Repos.Instance() == null)
      {
        _dah.Login();
        var p=_dah.GetResponse("Passenger/").Content.ReadAsStringAsync().Result;
        var f=_dah.GetResponse("Flight/").Content.ReadAsStringAsync().Result;
        var b=_dah.GetResponse("Booking/").Content.ReadAsStringAsync().Result;
        var passengers = ModelConverter.ModelToPassList(JsonConvert.DeserializeObject<List<PassengerModel>>(p));
        var flights = ModelConverter.ModelToFlightList(JsonConvert.DeserializeObject<List<FlightModel>>(f));
        var bookings = ModelConverter.ModelToBookList(JsonConvert.DeserializeObject<List<BookingModel>>(b));
        _repo = Repos.Instance(passengers, flights, bookings);
        _dah.Logout();
      }
      _repo = Repos.Instance();   
    }

    public HttpResponseMessage Get()
    {
      return Request.CreateResponse<List<PassengerModel>>(HttpStatusCode.OK, ModelConverter.PassToModelList(_repo.GetAllPassengers()));

    }
    // GET: api/Passenger
    public HttpResponseMessage Get(string email)
    {
      try
      {
        var pass = ModelConverter.PassToModel(_repo.GetPassenger(email));
        if (pass != null)
        {
          return Request.CreateResponse<PassengerModel>(HttpStatusCode.OK, pass);
        }

        return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "could not find passenger");
      }
      catch (Exception e)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
      }

    }

    // POST: api/Passenger
    public HttpResponseMessage Post(PassengerModel passenger)
    {
      try
      {
        if (!_repo.CheckIfPassengerExist(passenger.Email))
        {
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
        return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "email already taken");
      }
      catch (Exception e)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
      }
    }

    // PUT: api/Passenger/5
    public HttpResponseMessage Put(PassengerModel passenger)
    {
      try
      {
        if (_repo.CheckIfPassengerExist(passenger.Email))
        {
          if (_dah.Login())
          {
            Task<HttpResponseMessage> task = _dah.PutTask<PassengerModel>("Passenger/", passenger);
            _repo.CreatePassenger<HttpResponseMessage>(ModelConverter.ModelToPass(passenger), task);
            _dah.Logout();
            task.Wait();

            //return task.Result;
            if (task.Result.IsSuccessStatusCode)
              return Request.CreateResponse<string>(HttpStatusCode.OK, "passenger updated");
            else return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "failed db save");
          }
          return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "Login Failed");

        }
        return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "email already taken");
      }
      catch (Exception e)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
      }
    }

    // DELETE: api/Passenger/5
    public HttpResponseMessage Delete(string email)
    {

      throw new NotImplementedException();
    }
  }
}
