using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace Infrastructure.Extentions;

public static class DependencyInjection
{
    public static IdentityBuilder ConfigureInfrastructure(this IServiceCollection services)
    {
        var builder = services.AddIdentity<UserIdentity, IdentityRole<uint>>((options) => {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
        .AddDefaultTokenProviders();
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/login";
            options.LogoutPath = "/logout";
        });

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return builder;
    }
}
