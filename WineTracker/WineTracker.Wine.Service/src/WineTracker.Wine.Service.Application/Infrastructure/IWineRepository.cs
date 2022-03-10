using WineTracker.Wine.Service.Domain.Wine;

namespace WineTracker.Wine.Service.Application.Infrastructure;

public interface IWineRepository
{
    ValueTask CreateWine(
        string name,
        string? producer,
        string? region,
        string? country,
        int? vintage,
        string? kind,
        int? price,
        IReadOnlyList<string>? grapeVarietals);
    
    ValueTask<WineAggregate> GetWine(Guid id);
    
    ValueTask<bool> WineExists(Guid id);
}