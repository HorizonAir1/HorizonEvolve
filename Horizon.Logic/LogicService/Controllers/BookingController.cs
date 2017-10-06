using Logic.Models;
using Logic.Repos;
using LogicService.Controllers.Handler;
using LogicService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LogicService.Controllers
{
  [AllowAnonymous]
  public class BookingController : ApiController
  {
    private DataAPIHandler _dah;
    private Repos _repo;

    public BookingController() : base()
    {
      _dah = DataAPIHandler.Instance;
      _repo = Repos.Instance(_dah.GetTask("Passenger/"), _dah.GetTask("Booking/"), _dah.GetTask("Flight/"));
    }

    public HttpResponseMessage Get()
    {
      return Request.CreateResponse<List<BookingModel>>(HttpStatusCode.OK, ModelConverter.BookToModelList(_repo.GetAllBookings()));
    }

    public HttpResponseMessage Get(string email)
    {//get all bookings for passenger from repo
      if (_repo.CheckIfPassengerExist(email))
        return Request.CreateResponse<List<BookingModel>>(HttpStatusCode.OK, ModelConverter.BookToModelList(_repo.GetAllPassengerBookings(email)));
      return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "no such passenger");
    }

    public HttpResponseMessage Post(BookingModel booking)
    {//create new booking for passenger
      try
      {
        if (_dah.Login())
        {
          Passenger p = _repo.GetPassenger(booking.Email);
          if (p!=null)
          {
           
            Task<HttpResponseMessage> createTask = _dah.PostTask<PassengerModel>("Passenger/", booking.passenger);
            _repo.CreatePassenger<HttpResponseMessage>(p, createTask);
            createTask.Wait();
            if (!createTask.Result.IsSuccessStatusCode)
            {
              _dah.Logout();
              return createTask.Result;
            }
          }
          Task<HttpResponseMessage> createBooking = _dah.PostTask<BookingModel>("Booking/", booking);
          _repo.CreateBooking(ModelConverter.ModelToBook(booking, p.Id), createBooking);
          createBooking.Wait();
          return createBooking.Result;
        }
        return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "Login Failed");
      }
      catch (Exception e)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
      }
    }

    // PUT: api/Booking/5
    public HttpResponseMessage Put(BookingModel booking)
    {//update booking for passenger use for cancel
      try
      {
        if (_dah.Login())
        {
          if (_repo.CheckIfPassengerExist(booking.Email) && _repo.CheckIfBookingExist(booking.booking_id))
          {
            Task<HttpResponseMessage> editBooking = _dah.PutTask<BookingModel>("Booking/", booking);
            _repo.EditCustomerBooking(ModelConverter.ModelToBook(booking,_repo.GetPassenger(booking.Email).Id), editBooking);
            editBooking.Wait();
            _dah.Logout();
            return editBooking.Result;
          }
          return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "no such Booking");
        }
        return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "Login Failed");
      }
      catch (Exception e)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
      }
    }

    // DELETE: api/Booking/5
    public HttpResponseMessage Delete(int bookingid)
    {//remove booking for passenger (admin)
      try
      {
        if (_dah.Login())
        {
          Booking booking= _repo.GetBooking(bookingid);
          if (booking!=null)
          {
            Task<HttpResponseMessage> deleteBooking = _dah.DeleteTask("Booking/" +bookingid.ToString() );
            _repo.EditCustomerBooking(booking, deleteBooking);
            deleteBooking.Wait();
            _dah.Logout();
            return deleteBooking.Result;
          }
          return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "no such Booking");
        }
        return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "Login Failed");
      }
      catch (Exception e)
      {
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
      }
    }
  }
}
