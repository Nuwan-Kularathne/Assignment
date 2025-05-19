using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Vypex.CodingChallenge.Application.Services.Interfaces;
using Vypex.CodingChallenge.Application.Validators;
using Vypex.CodingChallenge.Application.Services.Implementations;

namespace Vypex.CodingChallenge.Application
{
  public static class ApplicatonModule
  {
    public static IServiceCollection AddApplicatonModule(this IServiceCollection services)
    {
      services.AddScoped<IEmployeeService, EmployeeService>();
      services.AddAutoMapper(Assembly.GetExecutingAssembly());

      services.AddFluentValidationAutoValidation();
      services.AddValidatorsFromAssemblyContaining<CreateLeaveDtoValidator>();

      services.Configure<ApiBehaviorOptions>(options =>
      {
        options.InvalidModelStateResponseFactory = context =>
        {
          var errors = context.ModelState
              .Where(e => e.Value?.Errors.Count > 0)
              .Select(e => new
              {
                Field = e.Key,
                Errors = e.Value!.Errors.Select(er => er.ErrorMessage)
              });

          return new BadRequestObjectResult(new { Errors = errors });
        };
      });

      return services;
    }
  }
}
