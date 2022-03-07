using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Queries;
using ProjectManager.Domain;

namespace ProjectManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult> Get(int days)
        {
            var result = await _mediator.Send(new GetWeatherForecastQuery(days));
            return Ok(result);
        }
    }
}