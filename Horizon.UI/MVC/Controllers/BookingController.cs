using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            IEnumerable<Booking> bookings = new List<Booking>();

            return View(bookings);
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

                return RedirectToAction("Booking");
        }

        // GET: Booking/Edit/5
        public ActionResult EditBooking(int id)
        {
            Booking booking = null; //TODO: GetBooking(id)

            return View(booking);
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
