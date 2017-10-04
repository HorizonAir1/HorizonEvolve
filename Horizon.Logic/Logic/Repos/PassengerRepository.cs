using System.Collections.Generic;
using System.Linq;
using Logic.Database.Repositories;
using Logic.Models;

namespace Logic.Repos
{
    public class PassengerRepository : Repository<Passenger, int>, IPassengerRepository
    {
        public PassengerRepository(DataSource context)
            : base(context)
        {
        }
    }
}
