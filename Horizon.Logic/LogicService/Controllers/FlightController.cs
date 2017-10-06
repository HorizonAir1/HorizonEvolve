using Logic.Models;
using Logic.Repos;
using LogicService.Controllers.Handler;
using LogicService.Models;
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
      _repo = Repos.Instance(_dah.GetTask("Passenger/"), _dah.GetTask("Booking/"), _dah.GetTask("Flight/"));
    }

    public HttpResponseMessage Get()
    {//get all flights from repo
      return Request.CreateResponse<List<FlightModel>>(HttpStatusCode.OK, ModelConverter.FlightToModelList(_repo.GetAllFlights()));
    }

    public HttpResponseMessage Get(Search search)
    {//get all flights within search
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
