using Logic.Models;
using System.Data.Entity.ModelConfiguration;

namespace Database
{
    public class DataMapper
    {
        public static void Map(EntityTypeConfiguration<Aircraft> entity, string tableName = "Aircraft", string schema = "dbo")
        {
            entity.ToTable(tableName, schema);
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).HasColumnName("aircraft_id");

            entity.Property(a => a.Producer).HasColumnName("producer").HasMaxLength(50).IsRequired();
            entity.Property(a => a.ModelNumber).HasColumnName("model_num");
            entity.Property(a => a.SeatActual).HasColumnName("seat_actual");
            entity.Property(a => a.SeatMax).HasColumnName("seat_max");

            entity.HasMany(a => a.Flights).WithRequired(f => f.Aircraft).HasForeignKey(f => f.AircraftId).WillCascadeOnDelete(false);
        }

        public static void Map(EntityTypeConfiguration<Booking> entity, string tableName = "Booking", string schema = "dbo")
        {
            entity.ToTable(tableName, schema);
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id).HasColumnName("booking_id");

            entity.Property(b => b.PassengerId).HasColumnName("passenger_id");
            entity.Property(b => b.FlightId).HasColumnName("flight_id");
            entity.Property(b => b.SeatClassId).HasColumnName("seatclass_id");
            entity.Property(b => b.SeatNumber).HasColumnName("seat_number");
            entity.Property(b => b.BaggageNumber).HasColumnName("baggage_num");
            entity.Property(b => b.StatusId).HasColumnName("status_id");

            entity.HasRequired(b => b.Payment).WithRequiredPrincipal(p => p.Booking).Map(m => { m.ToTable("Payment"); m.MapKey("booking_id"); }).WillCascadeOnDelete(false);
        }

        public static void Map(EntityTypeConfiguration<BookingStatus> entity, string tableName = "BookingStatus", string schema = "dbo")
        {
            entity.ToTable(tableName, schema);
            entity.HasKey(bs => bs.Id);
            entity.Property(bs => bs.Id).HasColumnName("status_id");
            entity.Property(bs => bs.Status).HasColumnName("status");

            entity.HasMany(bs => bs.Bookings).WithRequired(b => b.Status).HasForeignKey(b => b.StatusId).WillCascadeOnDelete(false);


        }

        public static void Map(EntityTypeConfiguration<Flight> entity, string tableName = "Flight", string schema = "dbo")
        {
            entity.ToTable(tableName, schema);
            entity.HasKey(f => f.Id);
            entity.Property(f => f.Id).HasColumnName("flight_id");

            entity.Property(f => f.ArrivalTime).HasColumnName("arrival_time");
            entity.Property(f => f.ArrivalDate).HasColumnName("arrival_date");
            entity.Property(f => f.DepartTime).HasColumnName("depart_time");
            entity.Property(f => f.DepartDate).HasColumnName("depart_date");
            entity.Property(f => f.Destination).HasColumnName("destination");
            entity.Property(f => f.Departure).HasColumnName("departure");
            entity.Property(f => f.AircraftId).HasColumnName("aircraft_id");

            entity.HasMany(f => f.SeatingCharts).WithRequired(sc => sc.Flight).HasForeignKey(sc => sc.FlightId).WillCascadeOnDelete(false);
        }

        public static void Map(EntityTypeConfiguration<Passenger> entity, string tableName = "Passenger", string schema = "dbo")
        {
            entity.ToTable(tableName, schema);
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).HasColumnName("passenger_id");

            entity.Property(p => p.FirstName).HasColumnName("firstname").HasMaxLength(50).IsRequired();
            entity.Property(p => p.Middle).HasColumnName("middle").HasMaxLength(50).IsRequired();
            entity.Property(p => p.LastName).HasColumnName("lastname").HasMaxLength(50).IsRequired();
            entity.Property(p => p.BirthDate).HasColumnName("birth_date").HasColumnType("date");
            entity.Property(p => p.Address).HasColumnName("address").HasMaxLength(50).IsRequired();
            entity.Property(p => p.PhoneNumber).HasColumnName("tel_num").HasMaxLength(50).IsRequired();
            entity.Property(p => p.Email).HasColumnName("email").HasMaxLength(50).IsRequired();

            entity.HasMany(p => p.Bookings).WithRequired(b => b.Passenger).HasForeignKey(b => b.PassengerId).WillCascadeOnDelete(false);

        }

        public static void Map(EntityTypeConfiguration<Payment> entity, string tableName = "Payment", string schema = "dbo")
        {
            entity.ToTable(tableName, schema);
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).HasColumnName("payment_id");

            entity.Property(p => p.BookingId).HasColumnName("booking_id");
            entity.Property(p => p.PayAmount).HasColumnName("pay_amount").HasPrecision(18, 0);
            entity.Property(p => p.PayDate).HasColumnName("pay_date");
        }

        public static void Map(EntityTypeConfiguration<SeatClass> entity, string tableName = "SeatClass", string schema = "dbo")
        {
            entity.ToTable(tableName, schema);
            entity.HasKey(sc => sc.Id);
            entity.Property(sc => sc.Id).HasColumnName("seatclass_id");

            entity.Property(sc => sc.Description).HasColumnName("desc").HasMaxLength(50).IsRequired();
            entity.Property(sc => sc.PricingTier).HasColumnName("pricingTier");

            entity.HasMany(sc => sc.Bookings).WithRequired(b => b.SeatClass).HasForeignKey(b => b.SeatClassId);
        }

        public static void Map(EntityTypeConfiguration<SeatingChart> entity, string tableName = "SeatingChart", string schema = "dbo")
        {
            entity.ToTable(tableName, schema);
            entity.HasKey(sc => sc.Id);
            entity.Property(sc => sc.Id).HasColumnName("seat_id");

            entity.Property(sc => sc.Section).HasColumnName("section");
            entity.Property(sc => sc.Seat).HasColumnName("seat");
            entity.Property(sc => sc.IsTaken).HasColumnName("isTaken");
            entity.Property(sc => sc.FlightId).HasColumnName("flight_id");
        }
    }
}
