using Microsoft.Azure.CosmosEventSourcing.Aggregates;
using Microsoft.Azure.CosmosEventSourcing.Events;
using WineTracker.Wine.Service.Domain.Exceptions;
using WineTracker.Wine.Service.Domain.Wine.Events;

namespace WineTracker.Wine.Service.Domain.Wine;

public partial class WineAggregate
{
    public void Create(string name,
        string? producer,
        string? region,
        string? country,
        int? vintage,
        string? kind,
        int? price,
        IReadOnlyList<string>? grapeVarietals)
    {
        if (Events.Any(x => x is CreatedEvent) || NewEvents.Any(x => x is CreatedEvent))
        {
            throw new InvalidDomainOperationException(
                nameof(Create), 
                "the wine has already been created", 
                typeof(WineAggregate));
        }
        
        AddEvent(new CreatedEvent(name, producer, region, country, vintage, kind, price, grapeVarietals));
    }
    
    private void ApplyCreatedEvent(CreatedEvent createdEvent)
    {
        Name = createdEvent.Name;
        Producer = createdEvent.Producer;
        Region = createdEvent.Region;
        Country = createdEvent.Country;
        Vintage = createdEvent.Vintage;
        Kind = createdEvent.Kind;
        Price = createdEvent.Price;
        GrapeVarietals = new List<string>(createdEvent.GrapeVarietals ?? Array.Empty<string>());
        Status = StorageStatuses.Stored;
    }
}