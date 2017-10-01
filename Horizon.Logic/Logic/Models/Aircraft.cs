using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Aircraft : BaseModel<int>
    {
        //public int AircraftId { get; set; }
        public string Producer { get; set; }
        public int ModelNumber { get; set; }
        public int SeatActual { get; set; }
        public int SeatMax { get; set; }
    }
}
