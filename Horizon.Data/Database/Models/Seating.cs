using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Database.Models
{
    public class Seating
    {
        public static bool addSeat(int y)
        {
            using (var db = new HorizonData())
            {
                DataAccess.SeatingChart x = new SeatingChart();
                db.SeatingCharts.Add(x);
                db.SaveChanges();
                return true;
            }
         
        }
        //public static List<string> getSeat()
        //{
        //    using (var db = new HorizonData())
        //    {
        //        List<string> m = new List<string>();
        //        //DataAccess.SeatingChart x = db.SeatingCharts.Single(i => i.seat_id == );
        //        foreach(var t in db.SeatingCharts)
        //        {
        //            m.Add(t.ToString());
        //        }
        //        return m;
        //    }

        //}
        public static void updateSeat(int y, int z)
        {
            using (var db = new HorizonData())
            {
                DataAccess.SeatingChart x = db.SeatingCharts.SingleOrDefault(i => i.seat_id == y);
                x.seat= z;
                db.SaveChanges();

            }

        }
        public static void deleteBook(int y)
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
