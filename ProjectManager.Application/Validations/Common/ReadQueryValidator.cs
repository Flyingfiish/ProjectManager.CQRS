using FluentValidation;
using ProjectManager.Application.Queries;
using ProjectManager.Application.Queries.Common;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Validations.Common
{
    public class ReadQueryValidator<T> : AbstractValidator<ReadQuery<T>> where T : Entity, new()
    {
        public ReadQueryValidator()
        {
            RuleFor(q => q.spec)
                .NotNull();
        }
    }

    public class GetWeatherForecastQueryValidator : AbstractValidator<GetWeatherForecastQuery>
    {
        public GetWeatherForecastQueryValidator()
        {
            RuleFor(q => q.days).GreaterThan(0);
        }
    }
}
