using System.Collections.Generic;
using System.Linq;
using Logic.Database.Repositories;
using Logic.Models;

namespace Database.Repositories
{
    public class AircraftRepository : Repository<Aircraft, int>, IAircraftRepository
    {
        public AircraftRepository(DataSource context)
            : base(context)
        {
        }
    }
}
