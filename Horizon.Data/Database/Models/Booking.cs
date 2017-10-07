using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Database.Models
{
    class Booking
    {
   
        public static DataAccess.Booking getBook(int y)
        {
            using (var db = new HorizonData())
            {
             
                DataAccess.Booking x = db.Bookings.SingleOrDefault(i => i.booking_id == y);
                return x;
            }

        }
        public static bool updateBook(int y,int a, int b, int c, int d, int e , int f)
        {
            using (var db = new HorizonData())
            {
                DataAccess.Booking x = db.Bookings.SingleOrDefault(i => i.booking_id == y);
                x.baggage_num = a;
                x.flight_id = b;
                x.passenger_id = c;
                x.seatclass_id = d;
                x.seat_number = e;
                x.status_id = f;
                db.SaveChanges();
                return true;

            }

        }
        public static bool deleteBook(int y)
        {
            using (var db = new HorizonData())
            {
                DataAccess.Booking x = db.Bookings.Single(i => i.booking_id == y);
                db.Bookings.Remove(x);
                db.SaveChanges();
                return true;
            }

        }

    public static IEnumerable<DataAccess.Booking> GetAllBookings()
    {
      //List<DataAccess.Booking> bookings = new List<DataAccess.Booking>();
      //using (var db = new HorizonData())
      //{
      //  foreach (var item in db.Bookings)
      //  {
      //    bookings.Add(item);
      //  }

      //}
      //return bookings;
      var db = new HorizonData();
      return db.Bookings;
    }
  }
}
