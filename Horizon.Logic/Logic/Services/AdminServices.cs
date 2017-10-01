using Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    class AdminServices : ClientServices
    {
        public AdminServices(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
