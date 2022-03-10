using Microsoft.Azure.CosmosEventSourcing.Aggregates;

namespace WineTracker.Wine.Service.Infrastructure.Repositories;

public interface IPartitionKeyResolver<TAggregate>
    where TAggregate : IAggregateRoot
{
    static abstract string GetPartitionKey(TAggregate aggregate);
}