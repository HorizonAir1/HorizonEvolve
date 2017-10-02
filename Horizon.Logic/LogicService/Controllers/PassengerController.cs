using LogicService.Controllers.Helpers;
using LogicService.Models;
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
  public class PassengerController : ApiController
  {
    // GET: api/Passenger
    public HttpResponseMessage Get(PassengerModel passenger)
    {
      if (DataAccountHelper.Login())
      {
        var client = new HttpClient();
        var res = client.GetAsync(ConfigurationManager.AppSettings["DataUri"] + "Passenger/").GetAwaiter().GetResult();
        DataAccountHelper.Logout();
        return res;

      }
      return Request.CreateResponse<string>(HttpStatusCode.Unauthorized, "Login Failed");
    }

    // POST: api/Passenger
    public HttpResponseMessage Post(PassengerModel passenger)
    {
      if (DataAccountHelper.Login())
      {
        var client = new HttpClient();
        var res = client.PostAsJsonAsync<PassengerModel>(ConfigurationManager.AppSettings["DataUri"] + "Passenger/", passenger).GetAwaiter().GetResult();
        DataAccountHelper.Logout();
        return res;

      }
      return Request.CreateResponse<string>(HttpStatusCode.Unauthorized, "Login Failed");
    }

    // PUT: api/Passenger/5
    public HttpResponseMessage Put(PassengerModel passenger)
    {
      if (DataAccountHelper.Login())
      {
        var client = new HttpClient();
        var res = client.PutAsJsonAsync<PassengerModel>(ConfigurationManager.AppSettings["DataUri"] + "Passenger/", passenger).GetAwaiter().GetResult();
        DataAccountHelper.Logout();
        return res;

      }
      return Request.CreateResponse<string>(HttpStatusCode.Unauthorized, "Login Failed");
    }

    // DELETE: api/Passenger/5
    public HttpResponseMessage Delete(string email)
    {
      if (DataAccountHelper.Login())
      {
        var client = new HttpClient();
        var res = client.DeleteAsync(ConfigurationManager.AppSettings["DataUri"] + "Passenger/" +email).GetAwaiter().GetResult();
        DataAccountHelper.Logout();
        return res;

      }
      return Request.CreateResponse<string>(HttpStatusCode.Unauthorized, "Login Failed");
    } 
  }
}
