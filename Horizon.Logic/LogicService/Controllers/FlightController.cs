using Logic.Models;
using Logic.Repos;
using LogicService.Controllers.Handler;
using LogicService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LogicService.Controllers
{
  public class FlightController : ApiController
  {
    private DataAPIHandler _dah;
    private Repos _repo;

    public FlightController() : base()
    {
      _dah = DataAPIHandler.Instance;
      if (Repos.Instance() == null)
      {
        _dah.Login();
        var p = _dah.GetResponse("Passenger/").Content.ReadAsStringAsync().Result;
        var f = _dah.GetResponse("Flight/").Content.ReadAsStringAsync().Result;
        var b = _dah.GetResponse("Booking/").Content.ReadAsStringAsync().Result;
        var passengers = ModelConverter.ModelToPassList(JsonConvert.DeserializeObject<List<PassengerModel>>(p));
        var flights = ModelConverter.ModelToFlightList(JsonConvert.DeserializeObject<List<FlightModel>>(f));
        var bookings = ModelConverter.ModelToBookList(JsonConvert.DeserializeObject<List<BookingModel>>(b));
        _repo = Repos.Instance(passengers, flights, bookings);
        _dah.Logout();
      }
      _repo = Repos.Instance();
    }

    public HttpResponseMessage Get()
    {//get all flights from repo
      return Request.CreateResponse<List<FlightModel>>(HttpStatusCode.OK, ModelConverter.FlightToModelList(_repo.GetAllFlights()));
    }

    public HttpResponseMessage Get(Search search)
    {//get all flights within search
      return Request.CreateResponse<Search>(HttpStatusCode.OK, search);
      List<Flight> flights = _repo.GetAvailableFlightsWithDuration(search.StartLoc, search.EndLoc, search.StartTime, search.EndTime);
      return Request.CreateResponse<List<FlightModel>>(HttpStatusCode.OK, ModelConverter.FlightToModelList(flights));
    }


    // POST: api/Flight
    public HttpResponseMessage Post(FlightModel flight)
    {//create a flight 
      if (_dah.Login())
      {
        Flight f = ModelConverter.ModelToFlight(flight);
        Task<HttpResponseMessage> addtask = _dah.PostTask<FlightModel>("Flight/", flight);
        _repo.AddFlight<HttpResponseMessage>(ModelConverter.ModelToFlight(flight), addtask);
        addtask.Wait();
        return addtask.Result;
      }
      return Request.CreateResponse<string>(HttpStatusCode.InternalServerError, "logic->data fail");
    }

    // PUT: api/Flight/5
    public HttpResponseMessage Put(FlightModel flight)
    {//update flight
      //check logic to see if flight exists

      //update flight in repo and database (same time)

      throw new NotImplementedException();
    }

    // DELETE: api/Flight/5
    public HttpResponseMessage Delete(int id)
    {
      //check logic if flight exists

      //delete flight in repo ad database(same time)

      throw new NotImplementedException();
    }
  }
}
