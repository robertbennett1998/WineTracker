using WineTracker.Wine.Service.Domain.Exceptions;
using WineTracker.Wine.Service.Domain.Wine.Events;

namespace WineTracker.Wine.Service.Domain.Wine;

public partial class WineAggregate
{
    private static readonly StorageStatuses[] CanBeDrunkAtStatuses = 
    {
        StorageStatuses.Drinking,
        StorageStatuses.Stored
    };

    public void Drink()
    {
        if (CanBeDrunkAtStatuses.Contains(Status) is false)
        {
            throw new InvalidDomainOperationException(
                nameof(Drink),
                $"Cannot drink at the current stats {Status}", 
                typeof(WineAggregate));
        }
        
        AddEvent(new DrankEvent(DateTime.UtcNow.Date));
    }

    private void ApplyDrankEvent(DrankEvent drankEvent)
    {
        DrankDateUtc = drankEvent.DrankDateUtc;
        Status = StorageStatuses.Drank;
    }
}