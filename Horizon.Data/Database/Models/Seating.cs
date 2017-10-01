using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Database.Models
{
    class Seating
    {
        public static void addSeat(int y)
        {
            using (var db = new HorizonData())
            {
                DataAccess.SeatingChart x = new SeatingChart();
                db.SeatingCharts.Add(x);
                db.SaveChanges();
            }
        }
        public static DataAccess.SeatingChart getSeat(int y)
        {
            using (var db = new HorizonData())
            {

                DataAccess.SeatingChart x = db.SeatingCharts.Single(i => i.seat_id == y);
                return x;
            }

        }
        public static void updateSeat(int y, int z)
        {
            using (var db = new HorizonData())
            {
                DataAccess.SeatingChart x = db.SeatingCharts.SingleOrDefault(i => i.seat_id == y);
                x.seat= z;
                db.SaveChanges();

            }

        }
        public static void deleteBook()
        {
            using (var db = new HorizonData())
            {
                DataAccess.SeatingChart x = db.SeatingCharts.Single(i => i.seat_id == y);
                db.SeatingCharts.Remove(x);
                db.SaveChanges();
            }

        }
    }
}
