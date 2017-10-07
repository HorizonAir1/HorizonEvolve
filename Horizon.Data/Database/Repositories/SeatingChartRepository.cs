using System.Collections.Generic;
using System.Linq;
using Logic.Database.Repositories;
using Logic.Models;

namespace Database.Repositories
{
    public class SeatingChartRepository : Repository<SeatingChart, int>, ISeatingChartRepository
    {
        public SeatingChartRepository(DataSource context)
            : base(context)
        {
        }

        public IEnumerable<SeatingChart> GetAvailableSeatsByFlight(int flightId)
        {
            throw new System.NotImplementedException();
        }
    }
}

