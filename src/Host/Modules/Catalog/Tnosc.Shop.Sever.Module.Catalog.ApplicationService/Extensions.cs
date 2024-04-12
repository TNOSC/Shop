using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Tnosc.Shop.Sever.Module.Catalog.ApplicationService;
public static class Extensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Extensions).Assembly));
        services.AddValidatorsFromAssembly(typeof(Extensions).Assembly);
        return services;
    }
}
