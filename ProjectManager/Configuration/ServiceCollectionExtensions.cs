using FluentValidation;
using MediatR;
using ProjectManager.Application.CommandHandlers.Common;
using ProjectManager.Application.Commands.Common;
using ProjectManager.Application.Queries;
using ProjectManager.Application.Queries.Common;
using ProjectManager.Application.QueryHandlers.Common;
using ProjectManager.Application.Validations.Common;
using ProjectManager.Application.Validations.Users;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntity<T>(this IServiceCollection services) where T : Entity, new()
        {
            return services
                .AddScoped<IRequestHandler<CreateCommand<T>, T>, CreateHandler<T>>()
                .AddScoped<IRequestHandler<ReadQuery<T>, IEnumerable<T>>, ReadHandler<T>>()
                .AddScoped<IRequestHandler<UpdateCommand<T>, T>, UpdateHandler<T>>()
                .AddScoped<IRequestHandler<DeleteCommand<T>, Unit>, DeleteHandler<T>>();
        }

        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            //User
            services
                .AddScoped<IValidator<CreateCommand<User>>, CreateUserValidator>()
                .AddScoped<IValidator<GetWeatherForecastQuery>, GetWeatherForecastQueryValidator>();

            services
                .AddScoped<IValidator<ReadQuery<User>>, ReadQueryValidator<User>>()
                .AddScoped<IValidator<UpdateCommand<User>>, UpdateCommandValidator<User>>()
                .AddScoped<IValidator<DeleteCommand<User>>, DeleteCommandValidator<User>>();

            services.AddBasicEntityValidations<Company>();
            services.AddBasicEntityValidations<CompanyUser>();
            services.AddBasicEntityValidations<CompanyRole>();
            services.AddBasicEntityValidations<CompanyUserCompanyRole>();

            return services;
        }

        private static IServiceCollection AddBasicEntityValidations<T>(this IServiceCollection services) where T : Entity, new()
        {
            services
                .AddScoped<IValidator<CreateCommand<T>>, CreateCommandValidator<T>>()
                .AddScoped<IValidator<ReadQuery<T>>, ReadQueryValidator<T>>()
                .AddScoped<IValidator<UpdateCommand<T>>, UpdateCommandValidator<T>>()
                .AddScoped<IValidator<DeleteCommand<T>>, DeleteCommandValidator<T>>();

            return services;
        }
    }
}
