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
    // GET: api/Booking
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET: api/Booking/5
    public HttpResponseMessage Get(PassengerModel p)
    {
      var client = new HttpClient();
      var res = client.GetAsync(ConfigurationManager.AppSettings["DataUri"] + "Account/").GetAwaiter().GetResult();
      throw new NotImplementedException();
    }

    // POST: api/Booking
    public HttpResponseMessage Post(BookingModel booking)
    {
      var client = new HttpClient();
      var res = client.GetAsync(ConfigurationManager.AppSettings["DataUri"] + "Passenger/").GetAwaiter().GetResult();
      if (res.IsSuccessStatusCode)
      {
        var r = res.Content.ReadAsStringAsync().Result;
        var p = JsonConvert.DeserializeObject<List<PassengerModel>>(r);

        if (!lh.VerifyPassenger(p,booking as PassengerModel))
        {
          var createpass = client.PostAsJsonAsync<PassengerModel>(ConfigurationManager.AppSettings["DataUri"] + "Passenger/", booking).GetAwaiter().GetResult();
          if (!createpass.IsSuccessStatusCode)
          {
            return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "create passenger failed");
          }
        }
        var getflights = client.GetAsync(ConfigurationManager.AppSettings["DataUri"] + "Flight/").GetAwaiter().GetResult();
        if (!getflights.IsSuccessStatusCode)
        {
          return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "get all flights failed");
        }
        var flights = getflights.Content.ReadAsStringAsync().Result;
        var f = JsonConvert.DeserializeObject<List<FlightModel>>(flights);
        if (!lh.VerifyFlight())
          return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Flight does not exist");
        var createbook = client.PostAsJsonAsync<BookingModel>(ConfigurationManager.AppSettings["DataUri"] + "Booking/", booking).GetAwaiter().GetResult();
        if (createbook.IsSuccessStatusCode)
          return Request.CreateResponse<string>(HttpStatusCode.OK, "Booking success");
        return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "book failed");
      }
      return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "get passenger list failed");
      
    }

    // PUT: api/Booking/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/Booking/5
    public void Delete(int id)
    {
    }
  }
}
