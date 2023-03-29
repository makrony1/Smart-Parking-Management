using Microsoft.AspNetCore.Mvc;
using SPM.BL.Interfaces;
using SPM.Model.ResponseModel;

namespace SPM.Web.Controllers
{
    [Route("api/Dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private IReportService _reportService;
        public DashboardController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public DashboardReport Get()
        {
            var totalParked = _reportService.GetTotalCarParked();
            var available = _reportService.GetTotalAvailParkingByGroup();
            var income = _reportService.GetIncomeForLatMonth();

            DashboardReport result = new DashboardReport()
            {
                AvailableParking = available,
                TaotalEarning = income,
                TotalParked = totalParked,
            };

            return result;
        }

    }
}
