using DatabaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatabaseAPI.Controllers
{
  [Authorize]
  public class FlightController : ApiController
  {
    private FacadeHelper fh = FacadeHelper.Instance;
    // GET api/values
    public HttpResponseMessage Get()
    {
      return Request.CreateResponse<List<DataAccess.Flight>>(HttpStatusCode.OK, fh.GetAllFlights());
    }

    // GET api/values/5
    //public HttpResponseMessage Get(FlightModel flight)
    //{
    //  FlightModel getFlight = fh.GetFlight(flight);
    //  if (getFlight != null)
    //  {
    //    return Request.CreateResponse<FlightModel>(HttpStatusCode.OK, getFlight);
    //  }
    //  return Request.CreateResponse<string>(HttpStatusCode.NotFound, "no existing flight");
    //}

    // POST api/values
    public HttpResponseMessage Post([FromBody]FlightModel flight)
    {
            var x = fh.CreateFlight(flight);
            if (x == true)
                return Request.CreateResponse<string>(HttpStatusCode.OK, "flight created");
            return Request.CreateResponse<string>(HttpStatusCode.NotFound, "create flight failed");
    }

    // PUT api/values/5
    public HttpResponseMessage Put(int id, [FromBody]FlightModel flight,BookingModel book)
    {
            var x = fh.updateBook(flight,book);
            if (x == true)
                return Request.CreateResponse<string>(HttpStatusCode.OK, "flight updated");
            return Request.CreateResponse<string>(HttpStatusCode.NotFound, "flight update failed");

    }

    // DELETE api/values/5
    public HttpResponseMessage Delete(FlightModel flight)
    {
            var x = fh.DeleteFlight(flight);

            if (x == true)
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Flight deleted");
            return Request.CreateResponse<string>(HttpStatusCode.NotFound, "flight delete failed");
    }
  }
}
