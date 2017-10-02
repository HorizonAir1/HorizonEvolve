using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatabaseAPI.Controllers
{
  public class BookingController : ApiController
  {
    // GET: api/Booking
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET: api/Booking/5
    public string Get(int id)
    {
      return "value";
    }

    // POST: api/Booking
    public void Post([FromBody]string value)
    {
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
