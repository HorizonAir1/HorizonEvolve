using System.Collections.Generic;
using System.Linq;
using Logic.Database.Repositories;
using Logic.Models;

namespace Database.Repositories
{
    public class BookingRepository : Repository<Booking, int>, IBookingRepository
    {
        public BookingRepository(DataSource context)
            : base(context)
        {
        }

        public IEnumerable<Booking> GetFutureBookingsByPassenger(int passengerId)
        {
            //TODO: Find the future booking for the passenger who has the passenger id passed in
            throw new System.NotImplementedException();
        }
    }
}
