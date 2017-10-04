﻿using System.Collections.Generic;
using System.Linq;
using Logic.Database.Repositories;
using Logic.Models;

namespace Logic.Repos
{
    public class BookingStatusRepository : Repository<BookingStatus, int>, IBookingStatusRepository
    {
        public BookingStatusRepository(DataSource context)
            : base(context)
        {
        }
    }
}
