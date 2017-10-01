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
    public HttpResponseMessage Get(Passenger passenger)
    {
      if (Login())
      {

        var client = new HttpClient();
        var res = client.GetAsync(ConfigurationManager.AppSettings["DataUri"] + "Passenger/").GetAwaiter().GetResult();
        //Logout();
        return res;

      }
      return Request.CreateResponse<string>(HttpStatusCode.Unauthorized, "Login Failed");
    }

    // GET: api/Passenger/5
    public string Get(int id)
    {

      return "value";
    }

    // POST: api/Passenger
    public void Post([FromBody]string value)
    {
    }

    // PUT: api/Passenger/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/Passenger/5
    public void Delete(int id)
    {
    }

    private bool Login()
    {
      var client = new HttpClient();
      var res = client.PostAsJsonAsync<UserProfile>(ConfigurationManager.AppSettings["DataUri"] + "Account/", new UserProfile()
      {
        Username = ConfigurationManager.AppSettings["DataUser"],
        Password = ConfigurationManager.AppSettings["DataPass"]
      }).GetAwaiter().GetResult();

      return res.IsSuccessStatusCode;
    }

    private bool Logout()
    {
      var client = new HttpClient();
      var res = client.DeleteAsync(ConfigurationManager.AppSettings["DataUri"] + "Account/").GetAwaiter().GetResult();

      return res.IsSuccessStatusCode;
    }
  }
}
