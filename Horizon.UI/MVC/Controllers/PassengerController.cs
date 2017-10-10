using MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PassengerController : Controller
    {
        // GET: Passenger
        public ActionResult Index()
        {
            IEnumerable<Passenger> passengers = new List<Passenger>();

            return View(passengers);
        }

        // GET: Passenger/Create
        public ActionResult CreatePassenger()
        {
            return View();
        }

        // POST: Passenger/Create
        [HttpPost]
        public ActionResult CreatePassenger(Passenger passenger)
        {
            //TODO: CreatePassenger(passenger);

            return RedirectToAction("Index");
        }

        // GET: Passenger/Edit/5
        public ActionResult EditPassenger(int passengerId)
        {
            //TODO: GetPassenger(passengerId);

            return View();
        }

        // POST: Passenger/Edit/5
        [HttpPost]
        public ActionResult EditPassenger(int passengerId, Passenger passenger)
        {
            //TODO: GetPassenger(passengerId);

            return RedirectToAction("Index");
        }

        // GET: Passenger/Delete/5
        public ActionResult Delete(int passengerId)
        {
            //TODO: GetBooking(passengerId); & and RemoveBooking();

            return View();
        }

    }
}
