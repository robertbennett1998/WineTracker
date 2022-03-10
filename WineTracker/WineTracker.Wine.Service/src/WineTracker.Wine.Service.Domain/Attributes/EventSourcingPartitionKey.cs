namespace WineTracker.Wine.Service.Domain.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class EventSourcingPartitionKeyAttribute : Attribute
{
}