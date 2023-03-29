using Microsoft.AspNetCore.Mvc;
using SPM.BL.Interfaces;
using SPM.Model.ResponseModel;
using SPM.Models.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPM.Web.Controllers
{
    [Route("api/Park")]
    [ApiController]
    public class ParkController : ControllerBase
    {
        private IParkService _parkService;
        public ParkController(IParkService parkService)
        {
            _parkService = parkService;
        }

        // POST api/<ParkController>
        [HttpPost]
        [Route("/checkin")]
        public CheckinResponse Checkin([FromBody] CheckinModel Checking)
        {
            var result = _parkService.Checkin(Checking);
            return result;
        }

        [HttpPost]
        [Route("/checkout")]
        public CheckoutResponse checkout([FromBody] CheckoutModel checkout)
        {
            var result = _parkService.Checkout(checkout);
            return result;
        }


    }
}
