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
    public HttpResponseMessage Get()
    {
      throw new NotImplementedException();
    }

    // GET: api/Booking/5
    public HttpResponseMessage Get(int id)
    {
      throw new NotImplementedException();
    }

    // POST: api/Booking
    public HttpResponseMessage Post(BookingModel booking)
    {
      if (fh.BookPassenger(booking))
        return Request.CreateResponse<string>(HttpStatusCode.OK, "book success");
      return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "book fail");
    }

    // PUT: api/Booking/5
    public HttpResponseMessage Put(int id, [FromBody]string value)
    {
      throw new NotImplementedException();

    }

    // DELETE: api/Booking/5
    public HttpResponseMessage Delete(int id)
    {
      throw new NotImplementedException();

    }
  }
}
