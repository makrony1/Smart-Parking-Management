using SPM.BL.Interfaces;
using SPM.DataAccess;
using SPM.DataAccess.Entity;
using SPM.Model.ResponseModel;
using SPM.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.BL.Services
{
    public class ParkService : IParkService
    {
        private IRepositoryWrapper _repository;
        public ParkService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public CheckinResponse Checkin(CheckinModel checkinModel)
        {
            Random rnd = new Random();
            int num = rnd.Next();
            var spaceTypeId = (num % 3) + 1;

            var parkingSpace = getAvailableParkingSpace(spaceTypeId);

            if(parkingSpace == null)
            {
                throw new Exception("No parking space available for the given category");
            }

            var park = getParkObj(checkinModel, parkingSpace);

            _repository.ParkRepo.Create(park);

            parkingSpace.IsOccpiped = true;
            _repository.ParkingSpaceRepo.Update(parkingSpace);


            _repository.Save();

            CheckinResponse result = new CheckinResponse()
            {
                ParkingSpot = parkingSpace.Name
            };
            return result;
        }

        public CheckoutResponse Checkout(CheckoutModel checkoutModel)
        {
            var checkoutTime = DateTime.Now;
            var park = _repository.ParkRepo.FindByCondition(p => p.VehiclePlate.Equals(checkoutModel.PlateNo.Trim())).FirstOrDefault();
            if (park == null)
            {
                return new CheckoutResponse()
                {
                    Success = false,
                    Message = "No vehicle found with this plate no."
                };
            }

            var parkingspace = getParkingSpaceFromId(park.ParkingSpaceId);
            var spacePrice = getSpacePriceBySpacetypeId(parkingspace.SpaceTypeId);
            double totalbillableHours = getTotalbillableHours(park.CheckinTime, checkoutTime);
            double totalPayable = spacePrice.RentPerHour * totalbillableHours;

            ParkingHistory ph = new ParkingHistory()
            {
                ParkingSpaceId = park.ParkingSpaceId,
                BillableHours = totalbillableHours,
                CheckinTime = park.CheckinTime,
                CheckoutTime = checkoutTime,
                CostPerHour = spacePrice.RentPerHour,
                TotalCost = totalPayable,
                VehiclePlate = park.VehiclePlate,
                VehicleTypeId = park.VehicleTypeId
            };

            _repository.ParkingHistoryRepo.Create(ph);
            _repository.ParkRepo.Delete(park);

            parkingspace.IsOccpiped = false;
            _repository.ParkingSpaceRepo.Update(parkingspace);

            Payment p = new Payment()
            {
                Amount = totalPayable,
                ParkingHistoryId = ph.Id,
                DateTime = DateTime.Now
            };

            _repository.PaymentRepo.Create(p);

            _repository.Save();

            return new CheckoutResponse()
            {
                Success = true,
                Message = $"Total billable hours:  {totalbillableHours}, Rate per hour {spacePrice.RentPerHour}, Total payment {totalPayable}"
            };
        }

        private VehicleType getVehicleType (string vehicalType)
        {
            var vehicleTypeObj = _repository.VehicleTypeRepo.FindByCondition(vt => vt.Type.Equals(vehicalType.Trim()))
                .FirstOrDefault();
            if(vehicleTypeObj == null)
            {
                vehicleTypeObj = new VehicleType()
                {
                    Type = vehicalType.Trim()
                };

                _repository.VehicleTypeRepo.Create(vehicleTypeObj);
                _repository.Save();
            }
            return vehicleTypeObj;
        }

        private Park getParkObj(CheckinModel checkinModel, ParkingSpace parkingSpace)
        {
            var vehicalType = getVehicleType(checkinModel.VehicleType);
            Park p = new Park()
            {
                VehiclePlate = checkinModel.PlateNo,
                VehicleTypeId = vehicalType.Id,
                ParkingSpaceId = parkingSpace.Id,
                CheckinTime = DateTime.Now
                

            };
            return p;
        }
        private double getTotalbillableHours(DateTime from, DateTime to)
        {
            TimeSpan duration = to - from;
            var totalhours = Math.Ceiling(duration.TotalHours);
            return totalhours; ;
        }

        private ParkingSpace getAvailableParkingSpace(int spaceTypeId)
        {
            return _repository.ParkingSpaceRepo.FindByCondition(pp => !pp.IsOccpiped && pp.IsAvailable && spaceTypeId == pp.SpaceTypeId).FirstOrDefault();
        }

        private ParkingSpace getParkingSpaceFromId(int id)
        {
            return _repository.ParkingSpaceRepo.FindByCondition(ps => ps.Id == id).First();
        }

        private SpacePrice getSpacePriceBySpacetypeId(int spaceTypeId)
        {
            return _repository.SpacePriceRepo.FindByCondition(ps => ps.Id == spaceTypeId).First();
        }
    }
}
