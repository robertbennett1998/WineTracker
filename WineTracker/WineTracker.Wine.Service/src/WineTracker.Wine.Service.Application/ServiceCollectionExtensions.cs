using Microsoft.Extensions.DependencyInjection;

namespace WineTracker.Wine.Service.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UsingWineServiceApplicationLayer(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}