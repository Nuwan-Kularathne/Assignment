using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vypex.CodingChallenge.Domain.Repositories;
using Vypex.CodingChallenge.Infrastructure.Data;
using Vypex.CodingChallenge.Infrastructure.Repositories;

namespace Vypex.CodingChallenge.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<CodingChallengeContext>(options => options
                .UseSqlite(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILeaveDayRepository, LeaveDayRepository>();
      
            return services;
        }
    }
}
