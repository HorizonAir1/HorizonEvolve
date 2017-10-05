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

namespace LogicService.Controllers
{
  [AllowAnonymous]
  public class PassengerController : ApiController
  {
    private DataAPIHandler _dah;
    private Repos _repo;

    public PassengerController():base()
    {
      _dah = DataAPIHandler.Instance;
      _repo = Repos.Instance(_dah.GetTask("Passenger/"), _dah.GetTask("Booking/"), _dah.GetTask("Flight/"));
    }

    // GET: api/Passenger
    public HttpResponseMessage Get(PassengerModel passenger)
    {
      if (_dah.Login())
      {
        var res = _dah.GetResponse("Passenger/");
        _dah.Logout();
        return res;
      }
      return Request.CreateResponse<string>(HttpStatusCode.Unauthorized, "Login Failed");
    }

    // POST: api/Passenger
    public HttpResponseMessage Post(PassengerModel passenger)
    {
      if (_dah.Login())
      {
        var res = _dah.PostResponse<PassengerModel>("Passenger/", passenger);
        _dah.Logout();
        return res;

      }
      return Request.CreateResponse<string>(HttpStatusCode.Unauthorized, "Login Failed");
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
