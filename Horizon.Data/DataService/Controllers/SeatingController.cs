﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataService.Controllers
{
    public class SeatingController : ApiController
    {
        // GET: api/Seating
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Seating/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Seating
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Seating/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Seating/5
        public void Delete(int id)
        {
        }
    }
}
