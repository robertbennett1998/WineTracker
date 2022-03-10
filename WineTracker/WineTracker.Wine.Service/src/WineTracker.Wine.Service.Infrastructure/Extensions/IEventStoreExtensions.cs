using System.Reflection;
using Microsoft.Azure.CosmosEventSourcing.Aggregates;
using Microsoft.Azure.CosmosEventSourcing.Items;
using Microsoft.Azure.CosmosEventSourcing.Stores;
using WineTracker.Wine.Service.Domain.Attributes;
using WineTracker.Wine.Service.Infrastructure.Repositories;

namespace WineTracker.Wine.Service.Infrastructure.Extensions;

public static class IEventStoreExtensions
{
    public static async ValueTask PersistAsync<TEventItem, TAggregate>(
        this IEventStore<TEventItem> eventStore, 
        TAggregate aggregate)
        where TAggregate : IAggregateRoot
        where TEventItem : EventItem, IPartitionKeyResolver<TAggregate>
    {

        var events = aggregate.NewEvents.Select(x => 
            Activator.CreateInstance(
                typeof(TEventItem), 
                x, 
                TEventItem.GetPartitionKey(aggregate)) as TEventItem).ToList();
        
        events.Add(Activator.CreateInstance(
            typeof(TEventItem), 
            aggregate.AtomicEvent, 
            TEventItem.GetPartitionKey(aggregate)) as TEventItem);

        if (events.Any(x => x == null))
        {
            throw new InvalidOperationException();
        }

        await eventStore.PersistAsync(events!);
    }
}