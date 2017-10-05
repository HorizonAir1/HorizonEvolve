using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Database.Repositories;
using Logic.Models;

namespace Logic.Repos
{
    public class FlightRepository : Repository<Flight, int>, IFlightRepository
    {
        public FlightRepository()
            : base()
        {
        }

        public IEnumerable<Flight> GetAvailFlightsWithDuration(string departLocation, string arrivalDestination, DateTime departDate, DateTime? returnDate)
        {
            throw new NotImplementedException();
        }

        public Flight GetWithDetails(int flightId)
        {
            throw new NotImplementedException();
        }
    }
}
