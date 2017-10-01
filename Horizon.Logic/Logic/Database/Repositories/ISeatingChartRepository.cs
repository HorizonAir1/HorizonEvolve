using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Database.Repositories
{
    public interface ISeatingChartRepository : IRepository<SeatingChart, int>
    {
        IEnumerable<SeatingChart> GetAvailableSeatsByFlight(int flightId);
    }
}
