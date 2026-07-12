using System.Reflection;

using CuraFlow.Application.Common.Behaviors;

using Microsoft.Extensions.DependencyInjection;

namespace CuraFlow.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(CachingBehavior<,>));
        });

        return services;
    }
}