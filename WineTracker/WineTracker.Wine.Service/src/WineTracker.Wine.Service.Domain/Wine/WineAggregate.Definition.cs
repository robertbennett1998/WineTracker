using Microsoft.Azure.CosmosEventSourcing.Aggregates;
using Microsoft.Azure.CosmosEventSourcing.Events;
using WineTracker.Wine.Service.Domain.Attributes;
using WineTracker.Wine.Service.Domain.Exceptions;
using WineTracker.Wine.Service.Domain.Wine.Events;

namespace WineTracker.Wine.Service.Domain.Wine;

public partial class WineAggregate : AggregateRoot
{
    public enum StorageStatuses
    {
        Unknown,
        Stored,
        Drinking,
        Drank,
        Removed,
        Gifted,
        Lost,
        Sold
    }

    [EventSourcingPartitionKey]
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Producer { get; private set; } 
    public string? Region { get; private set; }
    public string? Country { get; private set; } 
    public int? Vintage { get; private set; }
    public string? Kind { get; private set; }
    public int? Price { get; private set; }
    public List<string>? GrapeVarietals { get; private set; }
    public StorageStatuses Status { get; private set; }
    public DateTime DrankDateUtc { get; set; }
}