using Microsoft.Azure.CosmosEventSourcing.Events;

namespace WineTracker.Wine.Service.Domain.Wine.Events;

public record DrankEvent(DateTime DrankDateUtc) : DomainEvent;