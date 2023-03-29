using SPM.DataAccess.Entity;
using SPM.DataAccess.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.DataAccess.Repository
{
    public class VehicleTypeRepository : RepositoryBase<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(SPMDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
