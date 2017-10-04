using System.Collections.Generic;
using System.Linq;
using Logic.Database.Repositories;
using Logic.Models;

namespace Logic.Repos
{
    public class SeatClassRepository : Repository<SeatClass, int>, ISeatClassRepository
    {
        public SeatClassRepository(DataSource context)
            : base(context)
        {
        }
    }
}

