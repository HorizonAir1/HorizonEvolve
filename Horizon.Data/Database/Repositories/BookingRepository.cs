using System.Collections.Generic;
using System.Linq;
using Logic.Repos;
using Logic.Models;
using Logic.Database.Repositories;

namespace Database.Repositories
{
    public class BookingRepository : Repository<Booking, int>, IBookingRepository
    {
        public BookingRepository(DataSource context)
            : base(context)
        {
        }

        List<Booking> bookings = new List<Booking>();

        public IEnumerable<Booking> GetAllFutureBookings()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Booking> GetFutureBookingsByPassenger(int passengerId)
        {
            //TODO: Find the future booking for the passenger who has the passenger id passed in
            throw new System.NotImplementedException();
        }
    }
}
