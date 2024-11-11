using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Extentions;
using Persistence.Repositories;
using Persistence.Contexts;
using Domain.Repositories;
using System.Reflection;

namespace Persistence.Extentions;

public static class DependencyInjection
{
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Default"));
        });

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); // persistance
        });

        services.ConfigureInfrastructure()
                .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
    }
}
