using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewService service = new ViewService();
            Flight flight =  service.GetFlightDetails(1);
        }
    }
}
