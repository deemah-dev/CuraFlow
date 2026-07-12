namespace CuraFlow.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors();
        return services;
    }

    private static IServiceCollection AddCors(this IServiceCollection services)
    {
        services.AddCors(options => options.AddPolicy(
                "AllowAngular",
                policy =>
                policy
                .WithOrigins("http://localhost:7071").AllowAnyMethod().AllowAnyHeader()));
        return services;
    }
}