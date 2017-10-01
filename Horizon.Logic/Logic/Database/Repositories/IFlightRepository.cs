using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Database.Repositories
{
    public interface IFlightRepository : IRepository<Flight, int>
    {
        IEnumerable<Flight> GetAvailFlightsWithDuration(string departLocation, string arrivalDestination, DateTime departDate, DateTime? returnDate);
        Flight GetWithDetails(int flightId);
    }
}
