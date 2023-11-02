using IBGEChallenge.Application.Interfaces;
using IBGEChallenge.Application.Mapping;
using IBGEChallenge.Application.Services;
using IBGEChallenge.Domain.Interfaces;
using IBGEChallenge.Infra.Data;
using IBGEChallenge.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBGEChallenge.Infra.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("DATABASE") ?? configuration.GetConnectionString("ConnectionString");
            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            service.AddAutoMapper(typeof(MappingProfile));
            
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            service.AddScoped<ILocalityService, LocalityService>();
            service.AddScoped<IStateService, StateService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ITokenService, TokenService>();
            
            return service;
        }
    }
}