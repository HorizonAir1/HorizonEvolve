using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Database.Repositories
{
    public interface IBookingRepository : IRepository<Booking, int>
    {
        IEnumerable<Booking> GetFutureBookingsByPassenger(int passengerId);
    }
}
