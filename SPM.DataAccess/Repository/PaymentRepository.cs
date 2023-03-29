using SPM.DataAccess.Entity;
using SPM.DataAccess.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.DataAccess.Repository
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(SPMDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
