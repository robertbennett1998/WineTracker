using Convey;
using Convey.CQRS.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace WineTracker.Wine.Service.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UsingWineServiceApplicationLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddConvey()
            .AddCommandHandlers()
            .AddInMemoryCommandDispatcher();        
        
        return serviceCollection;
    }
}