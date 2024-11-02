using Microsoft.Extensions.DependencyInjection;
using Application.Common.Behaviors;
using System.Reflection;
using FluentValidation;
using MediatR;

namespace Application.Extentions;

public static class DependencyInjection
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        var assimbly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assimbly);

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assimbly);
        });

        services.AddValidatorsFromAssembly(assimbly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
