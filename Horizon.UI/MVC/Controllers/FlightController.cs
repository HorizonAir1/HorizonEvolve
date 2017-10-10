using MVC.Controllers.Handler;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
  public class FlightController : Controller
  {
    LogicAPIHandler _lah = LogicAPIHandler.Instance;
    // GET: Flight
    public ActionResult Index()
    {
      IEnumerable<Flight> flights = new List<Flight>();

      return View(flights);
    }

    // GET: Flight/Create
    public ActionResult CreateFlight()
    {
      return View();
    }

    // POST: Flight/Create
    [HttpPost]
    public ActionResult CreateFlight(Flight flight)
    {
      //TODO: CreateFlight(flight);
      var res=_lah.PostResponse<Flight>("Flight/", flight);
      if (res.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      return RedirectToAction("Index");
    }

    // GET: Flight/Edit/5
    public ActionResult EditFlight(int id)
    {
      //TODO: GetFlight(id);

      return View();
    }

    // POST: Flight/Edit/5
    [HttpPost]
    public ActionResult EditFlight(int flightId, Flight flight)
    {
      //Flight flightToUpdate = null; //TODO: GetFlight(id)
      //TODO: Send to FlightAPI

      return RedirectToAction("Index");
    }

    // GET: Flight/Delete/5
    public ActionResult DeleteFlight(int flightId)
    {
      //TODO: DeleteFlight(flightId);

      return View();
    }
  }
}
