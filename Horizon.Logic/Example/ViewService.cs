using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using Logic.Database;
using Database;
using Logic.Services;

namespace Example
{
    public class ViewService
    {
        IClientService clientService;

        public ViewService()
        {
            DataSource context = new DataSource();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            clientService = new ClientServices(unitOfWork);
        }

        public Flight GetFlightDetails(int flightId)
        {
            return clientService.GetFlightDetails(flightId);
        }
    }
}
