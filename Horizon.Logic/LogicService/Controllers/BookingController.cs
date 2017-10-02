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
  public class BookingController : ApiController
  {
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
    }

    // POST: api/Booking
    public void Post([FromBody]string value)
    {
      var client = new HttpClient();
      var res = client.PostAsJsonAsync(ConfigurationManager.AppSettings["DataUri"] + "Account/", JsonConvert.SerializeObject(new BookingModel ())).GetAwaiter().GetResult();
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
