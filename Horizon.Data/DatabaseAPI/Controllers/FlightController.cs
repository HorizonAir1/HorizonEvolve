﻿using DatabaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatabaseAPI.Controllers
{
  [AllowAnonymous]
  public class FlightController : ApiController
  {
    private FacadeHelper fh = FacadeHelper.Instance;
    // GET api/values
    public HttpResponseMessage Get()
    {
      return Request.CreateResponse<List<FlightModel>>(HttpStatusCode.OK, fh.GetAllFlights());
    }

    // GET api/values/5
    public HttpResponseMessage Get(FlightModel flight)
    {
      FlightModel getFlight = fh.GetFlight(flight);
      if (getFlight != null)
      {
        return Request.CreateResponse<FlightModel>(HttpStatusCode.OK, getFlight);
      }
      return Request.CreateResponse<string>(HttpStatusCode.NotFound, "no existing flight");
    }

    // POST api/values
    public void Post([FromBody]string value)
    {
    }

    // PUT api/values/5
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/values/5
    public void Delete(int id)
    {
    }
  }
}
