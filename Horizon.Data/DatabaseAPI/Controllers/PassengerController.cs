using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database.Models;
using DatabaseAPI.Models;

namespace DatabaseAPI.Controllers
{
    [AllowAnonymous]
    public class PassengerController : ApiController
    {
        private FacadeHelper fh = FacadeHelper.Instance;

        // GET: api/Passenger/5
        public HttpResponseMessage Get(PassengerModel Passenger)
        {
            try
            {
                var x= fh.GetPassenger(Passenger);
                if (x != null)
                    return Request.CreateResponse<PassengerModel>(HttpStatusCode.OK, x);
                return Request.CreateResponse<string>(HttpStatusCode.NotFound, "No such Passenger");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message, e);
            }

        }

        // POST: api/Passenger
        public HttpResponseMessage Post(PassengerModel passenger)
        {
            try
            {
                if (fh.CreatePassenger(passenger))
                    return Request.CreateResponse<string>(HttpStatusCode.OK, "Passenger Created");
                return Request.CreateResponse<string>(HttpStatusCode.NotFound, "Passenger Create Failed");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message, e);
            }
        }

        // PUT: api/Passenger/5
        public HttpResponseMessage Put(PassengerModel passenger)
        {
            try
            {
                if (fh.UpdatePassenger(passenger))
                    return Request.CreateResponse<string>(HttpStatusCode.OK, "Passenger Updated");
                return Request.CreateResponse<string>(HttpStatusCode.NotFound, "Passenger Update Failed");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message, e);
            }

        }

        // DELETE: api/Passenger/5
        //public HttpResponseMessage Delete(Passenger passenger)
        //{
        //    try
        //    {
        //        if (fh.)
        //            return Request.CreateResponse<string>(HttpStatusCode.OK, "Passenger Created");
        //        return Request.CreateResponse<string>(HttpStatusCode.NotFound, "Create Passenger Failed");
        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message, e);
        //    }
        //}
    }
}
