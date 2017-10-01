using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Passenger
    {
        public static bool cancelFly(int y, int z)
        {
            using (var db = new HorizonData())
            {
                DataAccess.Booking cancelB = new DataAccess.Booking();
                foreach (var i in db.Bookings)
                {
                    if ((i.passenger_id == y) && (i.flight_id == z))
                    {
                        cancelB = i;
                        break;
                    }
                }

                if (cancelB != null)
                {
                    // status_id 4.booked 5.CANCEL 6. ERROR
                    cancelB.status_id = 4;
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }
        public static bool modifyFly(int user, int flight, int seat)
        {
            using (var db = new HorizonData())
            {
                DataAccess.Booking cancelB = db.Bookings.Single(x => x.Passenger.passenger_id == user);
                if (cancelB != null)
                {
                    cancelB.Flight.flight_id = flight;
                    cancelB.seat_number = seat;
                    db.SaveChanges();
                    return true;
                }
                return false;

            }
        }
    }
}
