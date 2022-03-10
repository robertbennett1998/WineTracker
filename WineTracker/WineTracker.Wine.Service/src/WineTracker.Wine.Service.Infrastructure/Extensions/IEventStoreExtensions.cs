using System.Reflection;
using Microsoft.Azure.CosmosEventSourcing.Aggregates;
using Microsoft.Azure.CosmosEventSourcing.Items;
using Microsoft.Azure.CosmosEventSourcing.Stores;
using WineTracker.Wine.Service.Domain.Attributes;

namespace WineTracker.Wine.Service.Infrastructure.Extensions;

public static class IEventStoreExtensions
{
    public static async ValueTask PersistAsync<TEventItem>(
        this IEventStore<TEventItem> eventStore, 
        IAggregateRoot aggregateRoot, string? partitionKey = null)
        where TEventItem : EventItem
    {
        if (partitionKey is null)
        {
            PropertyInfo partitionKeyProperty = aggregateRoot
                .GetType()
                .GetProperties()
                .Single(x
                    => x.GetCustomAttributes()
                        .Any(y =>
                            y is EventSourcingPartitionKeyAttribute));
            
            partitionKey = partitionKeyProperty.GetValue(aggregateRoot)?.ToString() ?? 
                                throw new InvalidOperationException();
        }
        
        var events = aggregateRoot.NewEvents.Select(x => 
            Activator.CreateInstance(
                typeof(TEventItem), 
                x, 
                partitionKey) as TEventItem).ToList();
        
        events.Add(Activator.CreateInstance(
            typeof(TEventItem), 
            aggregateRoot.AtomicEvent, 
            partitionKey) as TEventItem);

        if (events.Any(x => x == null))
        {
            throw new InvalidOperationException();
        }

        await eventStore.PersistAsync(events!);
    }
}