using MVC.Controllers.Handler;
using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PassengerController : Controller
    {
        LogicAPIHandler _lah = LogicAPIHandler.Instance;

        // GET: Passenger
        public ActionResult Index()
        {
            IEnumerable<Passenger> passengers = new List<Passenger>();
            HttpResponseMessage res = _lah.GetResponse("Passenger/");

            if (res.IsSuccessStatusCode)
            {
                string p = res.Content.ReadAsStringAsync().Result;
                passengers = JsonConvert.DeserializeObject<List<Passenger>>(p);

                return View(passengers);
            }

            return View();
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
            HttpResponseMessage res = _lah.PostResponse("Passenger/", passenger);

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Passenger/Edit/5
        public ActionResult EditPassenger(int passengerId)
        {
            //TODO: GetPassenger(passengerId);
            HttpResponseMessage res = _lah.GetResponse("Passenger/");

            if (res.IsSuccessStatusCode)
            {
                return View(res);
            }

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
