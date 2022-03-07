using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProjectManager;
using ProjectManager.Application.QueryHandlers;
using ProjectManager.Application.Queries;
using ProjectManager.Controllers;
using ProjectManager.Domain;
using ProjectManager.Domain.Entities;
using ProjectManager.Infrastructure.EfCore;
using ProjectManager.Infrastructure.Repository;
using System.Reflection;
using ProjectManager.Application.Commands.Common;
using ProjectManager.Application.CommandHandlers.Common;
using ProjectManager.Application.Queries.Common;
using ProjectManager.Application.QueryHandlers.Common;
using ProjectManager.Configuration;
using FluentValidation;
using ProjectManager.Application.Validations.Common;
using ProjectManager.Application.Behaviors;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Diagnostics;
using ProjectManager.Application.Validations.Users;
using ProjectManager.Application;
using ProjectManager.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>, GetWeatherForecastHandler>();

builder.Services.AddValidations();

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddScoped<IPipelineBehavior<CreateCommand<User>, User>, HashPasswordBehaviour>();
//builder.Services.AddScoped<IPipelineBehavior<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>, ValidationBehaviour<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>>();

//Entities CRUD commands and queries
builder.Services.AddEntity<User>();
builder.Services.AddEntity<Company>();
builder.Services.AddEntity<CompanyUser>();
builder.Services.AddEntity<CompanyRole>();
builder.Services.AddEntity<CompanyUserCompanyRole>();

//Repositories
builder.Services.AddScoped<IRepository<User>, EFRepository<User>>();
builder.Services.AddScoped<IRepository<Company>, EFRepository<Company>>();
builder.Services.AddScoped<IRepository<CompanyUser>, EFRepository<CompanyUser>>();
builder.Services.AddScoped<IRepository<CompanyRole>, EFRepository<CompanyRole>>();
builder.Services.AddScoped<IRepository<CompanyUserCompanyRole>, EFRepository<CompanyUserCompanyRole>>();

//builder.Services.AddScoped<ICurrentUser, CurrentUserAdapter>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.RequireHttpsMetadata = false;
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,

            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,

            ValidateLifetime = true,

            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        .Get<IExceptionHandlerPathFeature>()
        .Error;
    var response = new
    {
        type = exception.GetType().Name,
        message = exception.Message,
        innerException = exception.InnerException,
        stackTrace = exception.StackTrace
    };
    await context.Response.WriteAsJsonAsync(response);
}));

app.UseRouting();

//app.UseInfrastructure(Configuration);

app.UseCors(builder =>
    builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
