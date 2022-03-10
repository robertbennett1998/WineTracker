using Microsoft.Azure.CosmosEventSourcing.Events;

namespace WineTracker.Wine.Service.Domain.Wine.Events;

public record CreatedEvent(
    Guid Id,
    string Name, 
    string? Producer, 
    string? Region, 
    string? Country, 
    int? Vintage,
    string? Kind,
    int? Price,
    IReadOnlyList<string>? GrapeVarietals) : DomainEvent;