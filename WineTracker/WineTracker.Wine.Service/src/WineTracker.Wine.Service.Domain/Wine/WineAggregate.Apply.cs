using Microsoft.Azure.CosmosEventSourcing.Aggregates;
using Microsoft.Azure.CosmosEventSourcing.Events;
using WineTracker.Wine.Service.Domain.Exceptions;
using WineTracker.Wine.Service.Domain.Wine.Events;

namespace WineTracker.Wine.Service.Domain.Wine;

public partial class WineAggregate
{
    protected override void Apply(DomainEvent domainEvent)
    {
        switch (domainEvent)
        {
            case CreatedEvent createdEvent:
                ApplyCreatedEvent(createdEvent);
                break;
            
            case DrankEvent drankEvent:
                ApplyDrankEvent(drankEvent);
                break;
            
            default:
                throw new UnhandledDomainEventException(typeof(WineAggregate), domainEvent.GetType());
        }
    }
}