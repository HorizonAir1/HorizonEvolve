﻿using System.Collections.Generic;
using System.Linq;
using Logic.Database.Repositories;
using Logic.Models;

namespace Logic.Repos
{
    public class BookingRepository : Repository<Booking, int>, IBookingRepository
    {
        public BookingRepository()
            : base()
        {
        }

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
