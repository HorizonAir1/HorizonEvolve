using MVC.Controllers.Handler;
using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BookingController : Controller
    {
        LogicAPIHandler _lah = LogicAPIHandler.Instance;

        // GET: Booking
        public ActionResult Index()
        {
            IEnumerable<Booking> bookings = new List<Booking>();
            HttpResponseMessage res = _lah.GetResponse("Booking/");
            if (res.IsSuccessStatusCode)
            {
                var f = res.Content.ReadAsStringAsync().Result;
                bookings = JsonConvert.DeserializeObject<List<Booking>>(f);

                return View(bookings);
            }

            return View();
        }

       // GET: Booking/Create
        public ActionResult CreateBooking()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult CreateBooking(Booking booking)
        {
            // TODO: CreateBooking(booking)
            HttpResponseMessage res = _lah.PostResponse<Booking>("Booking/", booking);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Booking");
            }

            return View();
        }

        // GET: Booking/Edit/5
        public ActionResult EditBooking(int bookingId)
        {
            //TODO: GetBooking(id)
            HttpResponseMessage res = _lah.GetResponse("Booking/" + bookingId.ToString());
            if (res.IsSuccessStatusCode)
            {
                return View(res);
            }

            return View();
        }

        // POST: Booking/Edit/5
        [HttpPost]
        public ActionResult EditBooking(int id, Booking booking)
        {
            //Booking bookingToUpdate = null; //TODO: GetBooking(id)
                //TODO: Send to bookingtoAPI

                return RedirectToAction("Index");
        }

        // GET: Booking/Delete/5
        public ActionResult DeleteBooking(int bookingid)
        {
            //TODO: DeleteBooking(bookingid);

            return View();
        }
    }
}
