using Microsoft.Azure.CosmosEventSourcing.Events;
using Microsoft.Azure.CosmosEventSourcing.Items;
using Microsoft.Azure.CosmosEventSourcing.Stores;
using WineTracker.Wine.Service.Application.Infrastructure;
using WineTracker.Wine.Service.Domain.Wine;
using WineTracker.Wine.Service.Infrastructure.Extensions;

namespace WineTracker.Wine.Service.Infrastructure.Repositories;

public sealed class WineRepository : IWineRepository
{
    private readonly IEventStore<EventItem> _eventStore;

    public class EventItem : DefaultEventItem
    {
        public EventItem(IDomainEvent domainEvent, Guid wineId) 
            : base(domainEvent, wineId.ToString())
        {
            
        }
        
        public EventItem(AtomicEvent atomic, Guid wineId) 
            : base(atomic, wineId.ToString())
        {
            
        }
        
        public EventItem(IDomainEvent domainEvent, string partitionKey) 
            : base(domainEvent, partitionKey)
        {
            
        }
        
        public EventItem(AtomicEvent atomic, string partitionKey) 
            : base(atomic, partitionKey)
        {
            
        }
    }

    public WineRepository(IEventStore<EventItem> eventStore)
    {
        _eventStore = eventStore;
    }
    
    public async ValueTask CreateWine(
        string name, 
        string? producer, 
        string? region, 
        string? country, 
        int? vintage, 
        string? kind,
        int? price, 
        IReadOnlyList<string>? grapeVarietals)
    {
        WineAggregate wine = WineAggregate.CreateWineAggregate(
            name,
            producer,
            region,
            country,
            vintage,
            kind,
            price,
            grapeVarietals);
        
        await _eventStore.PersistAsync(wine);
    }

    public ValueTask<WineAggregate> GetWine(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> WineExists(Guid id)
    {
        throw new NotImplementedException();
    }
}