using System.Data.Entity;
using Logic.Models;

namespace Database
{
    public class DataSource : DbContext
    {
        public DbSet<Aircraft> Aircrafts { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<BookingStatus> BookingStatuses { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<SeatClass> SeatClasses { get; set; }

        public DbSet<SeatingChart> SeatingCharts { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            DataMapper.Map(modelBuilder.Entity<Aircraft>());
            DataMapper.Map(modelBuilder.Entity<Booking>());
            DataMapper.Map(modelBuilder.Entity<BookingStatus>());
            DataMapper.Map(modelBuilder.Entity<Flight>());
            DataMapper.Map(modelBuilder.Entity<Passenger>());
            DataMapper.Map(modelBuilder.Entity<Payment>());
            DataMapper.Map(modelBuilder.Entity<SeatClass>());
            DataMapper.Map(modelBuilder.Entity<SeatingChart>());
        }
    }
}
