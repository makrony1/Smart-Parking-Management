using SPM.BL.Interfaces;
using SPM.DataAccess;
using SPM.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.BL.Services
{
    public class ReportService : IReportService
    {
        private IRepositoryWrapper _repository;
        public ReportService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IncomeReport GetIncomeForLatMonth()
        {
            var now = DateTime.Now;
            var before30Days = now.AddDays(-30);

            var amount = _repository.PaymentRepo.FindByCondition(p => p.DateTime >= before30Days).
                AsEnumerable().Sum(pp => pp.Amount);
            IncomeReport report = new IncomeReport()
            {
                DateFrom = before30Days.ToShortDateString(),
                DateTo = now.ToShortDateString(),
                Total = amount
            };

            return report;

        }

        public List<GroupByParking> GetTotalAvailParkingByGroup()
        {
            var alltype = _repository.SpaceTypeRepo.FindAll().ToList();
            var gpCount = _repository.ParkingSpaceRepo.FindByCondition(ps => !ps.IsOccpiped && ps.IsAvailable).AsEnumerable();
            var result = gpCount.GroupBy(ps=>ps.SpaceTypeId).
                Select(g => new GroupByParking
                {
                    Type= alltype.FirstOrDefault(at=>at.Id==g.Key).Name,
                    Count=g.Count()
                }).ToList();
            return result;
        }

        public int GetTotalCarParked()
        {
            var totalParked = _repository.ParkRepo.FindAll().Count();
            return totalParked;
            
        }
    }
}
