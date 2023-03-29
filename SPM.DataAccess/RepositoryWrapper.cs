using SPM.DataAccess.Interfaces.Repository;
using SPM.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.DataAccess
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SPMDbContext _repoContext;
        private IParkRepository _parkRepository;

        private IParkingHistoryRepository _parkingHistoryRepository;
        private IParkingSpaceRepository _parkingSpaceRepository;
        private IPaymentRepository _paymentRepository;
        private ISpacePriceRepository _spacePriceRepository;
        private ISpaceTypeRepository _spaceTypeRepository;
        private IVehicleTypeRepository _vehicleTypeRepository;
        public IParkRepository ParkRepo
        {
            get
            {
                if (_parkRepository == null)
                {
                    _parkRepository = new ParkRepository(_repoContext);
                }
                return _parkRepository;
            }
        }

        public IParkingHistoryRepository ParkingHistoryRepo
        {
            get
            {
                if (_parkingHistoryRepository == null)
                {
                    _parkingHistoryRepository = new ParkingHistoryRepository(_repoContext);
                }
                return _parkingHistoryRepository;
            }
        }

        public IParkingSpaceRepository ParkingSpaceRepo
        {
            get
            {
                if (_parkingSpaceRepository == null)
                {
                    _parkingSpaceRepository = new ParkingSpaceRepository(_repoContext);
                }
                return _parkingSpaceRepository;
            }
        }

        public IPaymentRepository PaymentRepo
        {
            get
            {
                if (_paymentRepository == null)
                {
                    _paymentRepository = new PaymentRepository(_repoContext);
                }
                return _paymentRepository;
            }
        }

        public ISpacePriceRepository SpacePriceRepo
        {
            get
            {
                if (_spacePriceRepository == null)
                {
                    _spacePriceRepository = new SpacePriceRepository(_repoContext);
                }
                return _spacePriceRepository;
            }
        }

        public ISpaceTypeRepository SpaceTypeRepo
        {
            get
            {
                if (_spaceTypeRepository== null)
                {
                    _spaceTypeRepository = new SpaceTypeRepository(_repoContext);
                }
                return _spaceTypeRepository;
            }
        }

        public IVehicleTypeRepository VehicleTypeRepo
        {
            get
            {
                if (_vehicleTypeRepository == null)
                {
                    _vehicleTypeRepository = new VehicleTypeRepository(_repoContext);
                }
                return _vehicleTypeRepository;
            }
        }

        public RepositoryWrapper(SPMDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
