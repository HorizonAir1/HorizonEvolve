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
      var x = fh.GetAllBookings();
      return Request.CreateResponse<List<BookingModel>>(HttpStatusCode.OK, x);
    }

    //public HttpResponseMessage Get(BookingModel book)
    //{
    //        var x = fh.GetBooking(book);
    //        if (x != null)
    //            return Request.CreateResponse<BookingModel>(HttpStatusCode.OK, x);
    //        return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "get fail");
    //}

   

    // POST: api/Booking
    public HttpResponseMessage Post(BookingModel booking)
    {
      if (fh.BookPassenger(booking))
        return Request.CreateResponse<string>(HttpStatusCode.OK, "book success");
      return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "book fail");
    }

    // PUT: api/Booking/5
    public HttpResponseMessage Put(FlightModel flight,BookingModel book)
    {
            if (fh.updateBook(flight, book))
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Update Book Success");
            return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Update Book Fail ");


    }

    // DELETE: api/Booking/5
    public HttpResponseMessage Delete(BookingModel book)
    {
            if (fh.deleteBook(book))
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Delete Book Success");
            return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Delete Book Fail");

    }
  }
}
