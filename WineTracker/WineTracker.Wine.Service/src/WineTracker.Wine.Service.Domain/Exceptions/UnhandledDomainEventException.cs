using System.Reflection;

namespace WineTracker.Wine.Service.Domain.Exceptions;

public sealed class UnhandledDomainEventException : DomainException
{
    public UnhandledDomainEventException(Type aggregateType, Type domainEventType) : base($"Couldn't apply {domainEventType.Name} to {aggregateType.Name}")
    {
    }
}