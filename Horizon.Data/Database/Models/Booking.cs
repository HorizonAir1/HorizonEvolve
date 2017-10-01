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
        public static void updateBook(int y, int z)
        {
            using (var db = new HorizonData())
            {
                DataAccess.Booking x = db.Bookings.SingleOrDefault(i => i.booking_id == y);
                x.flight_id = z;
                db.SaveChanges();

            }

        }
        public static void deleteBook()
        {
            using (var db = new HorizonData())
            {
                DataAccess.Booking x = db.Bookings.Single(i => i.booking_id == y);
                db.Bookings.Remove(x);
                db.SaveChanges();
            }

        }




    }
}
