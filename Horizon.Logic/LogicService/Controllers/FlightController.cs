using LogicService.Controllers.Handler;
using LogicService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LogicService.Controllers
{
  public class FlightController : ApiController
  {
    private DataAPIHandler _dah;
    private Repos _repo;

    public FlightController():base()
    {
      _dah = DataAPIHandler.Instance;
      _repo = Repos.Instance(_dah.GetTask("Passenger/"), _dah.GetTask("Booking/"), _dah.GetTask("Flight/"));
    }

    // GET: api/Flight
    public HttpResponseMessage Get()
    {//get all flights from repo
      throw new NotImplementedException();
    }

    // GET: api/Flight/5
    public HttpResponseMessage Get(string email)
    {// get all flights for passenger from repo
      throw new NotImplementedException();
    }

    public HttpResponseMessage Get(Search search)
    {
      return Request.CreateResponse<Search>(HttpStatusCode.OK, search);
    }

    // POST: api/Flight
    public HttpResponseMessage Post(FlightModel flight)
    {//create a flight 
      //check logic to see if flight can be made (not necessary, unless two shuttles cannot launch at the same time)

      //create flight in both repo and database (same time)

      throw new NotImplementedException();
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
