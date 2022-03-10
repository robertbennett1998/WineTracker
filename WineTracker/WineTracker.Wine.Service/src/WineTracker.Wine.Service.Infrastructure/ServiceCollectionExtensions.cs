using Microsoft.Azure.CosmosEventSourcing.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace WineTracker.Wine.Service.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UsingWineServiceInfrastructureLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCosmosEventSourcing(eventSourcingBuilder =>
        {
            eventSourcingBuilder.AddCosmosRepository(options =>
            {
                options.DatabaseId = "wine-service";
            });
        
            eventSourcingBuilder.AddDomainEventTypes();
            eventSourcingBuilder.AddDomainEventProjectionHandlers();
        });
        
        return serviceCollection;
    }
}