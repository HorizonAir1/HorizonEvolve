using DatabaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatabaseAPI.Controllers
{
  [AllowAnonymous]
  public class BookingController : ApiController
  {
    private FacadeHelper fh = FacadeHelper.Instance;
    // GET: api/Booking
    public HttpRequestMessage Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET: api/Booking/5
    public HttpRequestMessage Get(int id)
    {
      return "value";
    }

    // POST: api/Booking
    public HttpRequestMessage Post(BookingModel booking)
    {
      fh.BookPassenger()
    }

    // PUT: api/Booking/5
    public HttpRequestMessage Put(int id, [FromBody]string value)
    {
    }

    // DELETE: api/Booking/5
    public HttpRequestMessage Delete(int id)
    {
    }
  }
}
