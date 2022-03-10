using Microsoft.Azure.CosmosEventSourcing.Extensions;
using Microsoft.Extensions.DependencyInjection;
using WineTracker.Wine.Service.Application.Infrastructure;
using WineTracker.Wine.Service.Infrastructure.Repositories;

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
                options.ContainerBuilder.ConfigureEventItemStore<WineRepository.EventItem>("wine-events");
            });
        
            eventSourcingBuilder.AddDomainEventTypes();
        });

        serviceCollection.AddSingleton<IWineRepository, WineRepository>();
        
        return serviceCollection;
    }
}