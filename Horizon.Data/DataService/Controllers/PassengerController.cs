using DataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataService.Controllers
{
  [Authorize]
  public class PassengerController : ApiController
  {
    private FacadeHelper fh = FacadeHelper.Instance;

    public HttpResponseMessage Get()
    {
      return Request.CreateResponse<string>(HttpStatusCode.OK, "WE GOT HERE!!!");
    }

    // GET: api/Passenger/5
    //public HttpResponseMessage Get(Passenger Passenger)
    //{
    //  try
    //  {
    //    bool getPassenger = fh.GetPassenger(Passenger);
    //    if (getPassenger)
    //      return Request.CreateResponse<bool>(HttpStatusCode.OK, getPassenger);
    //    return Request.CreateResponse<string>(HttpStatusCode.NotFound, "No such Passenger");
    //  }
    //  catch (Exception e)
    //  {
    //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message, e);
    //  }

    //}

    //// POST: api/Passenger
    //public HttpResponseMessage Post(Passenger passenger)
    //{
    //  try
    //  {
    //    if (fh.CreatePassenger(passenger))
    //      return Request.CreateResponse<string>(HttpStatusCode.OK, "Passenger Created");
    //    return Request.CreateResponse<string>(HttpStatusCode.NotFound, "Passenger Create Failed");
    //  }
    //  catch(Exception e)
    //  {
    //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message, e);
    //  }
    //}

    //// PUT: api/Passenger/5
    //public HttpResponseMessage Put(Passenger passenger)
    //{
    //  try
    //  {
    //    if (fh.UpdatePassenger(passenger))
    //      return Request.CreateResponse<string>(HttpStatusCode.OK, "Passenger Updated");
    //    return Request.CreateResponse<string>(HttpStatusCode.NotFound, "Passenger Update Failed");
    //  }
    //  catch (Exception e)
    //  {
    //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message, e);
    //  }

    //}

    //// DELETE: api/Passenger/5
    //public HttpResponseMessage Delete(Passenger passenger)
    //{
    //  try
    //  {
    //    if (fh.RemovePassenger(passenger))
    //      return Request.CreateResponse<string>(HttpStatusCode.OK, "Passenger Created");
    //    return Request.CreateResponse<string>(HttpStatusCode.NotFound, "Create Passenger Failed");
    //  }
    //  catch (Exception e)
    //  {
    //    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message, e);
    //  }
    //}
  }
}
