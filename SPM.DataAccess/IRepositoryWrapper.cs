using SPM.DataAccess.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.DataAccess
{
    public interface IRepositoryWrapper
    {
        IParkRepository ParkRepo { get; }
        IParkingHistoryRepository ParkingHistoryRepo { get; }
        IParkingSpaceRepository ParkingSpaceRepo { get; }
        IPaymentRepository PaymentRepo { get; }
        ISpacePriceRepository SpacePriceRepo { get; }
        ISpaceTypeRepository SpaceTypeRepo { get; }
        IVehicleTypeRepository VehicleTypeRepo { get; }
        void Save();
    }
}
