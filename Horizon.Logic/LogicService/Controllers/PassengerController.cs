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
      _dah.Login();
      _repo = Repos.Instance(_dah.GetTask("Passenger/"), _dah.GetTask("Booking/"), _dah.GetTask("Flight/"));
      _dah.Logout();
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
      //if (_dah.Login())
      //{
      //  var res = client.PutAsJsonAsync<PassengerModel>(ConfigurationManager.AppSettings["DataUri"] + "Passenger/", passenger).GetAwaiter().GetResult();
      //  _dah.Logout();
      //  return res;

      //}
      //return Request.CreateResponse<string>(HttpStatusCode.Unauthorized, "Login Failed");
      throw new NotImplementedException();
    }

    // DELETE: api/Passenger/5
    public HttpResponseMessage Delete(string email)
    {
      //if (_dah.Login())
      //{
      //  var client = new HttpClient();
      //  var res = client.DeleteAsync(ConfigurationManager.AppSettings["DataUri"] + "Passenger/" +email).GetAwaiter().GetResult();
      //  _dah.Logout();
      //  return res;

      //}
      //return Request.CreateResponse<string>(HttpStatusCode.Unauthorized, "Login Failed");

      throw new NotImplementedException();
    }
  }
}
