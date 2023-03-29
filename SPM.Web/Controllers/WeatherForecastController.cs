using Microsoft.AspNetCore.Mvc;
using SPM.DataAccess;
using SPM.DataAccess.Entity;

namespace SPM.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private IRepositoryWrapper _repository;
        

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            Park p = new Park();
            p.CheckinTime = DateTime.Now;
            p.VehicleTypeId = 1;
            p.VehiclePlate = "AZ 123";

            _repository.ParkRepo.Create(p);
            _repository.Save();


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}