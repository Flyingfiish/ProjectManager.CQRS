using MediatR;
using ProjectManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Queries
{
    public record GetWeatherForecastQuery(int days) : IRequest<IEnumerable<WeatherForecast>>;
}
