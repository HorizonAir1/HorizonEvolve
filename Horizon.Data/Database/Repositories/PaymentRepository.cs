using System.Collections.Generic;
using System.Linq;
using Logic.Database.Repositories;
using Logic.Models;

namespace Database.Repositories
{
    public class PaymentRepository : Repository<Payment, int>, IPaymentRepository
    {
        public PaymentRepository(DataSource context)
            : base(context)
        {
        }
    }
}

