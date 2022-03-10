namespace WineTracker.Wine.Service.Domain.Exceptions;

public sealed class InvalidDomainOperationException : DomainException
{
    public InvalidDomainOperationException(string operationName, string reason, Type aggregateType) : base(
        $"Cannot apply {operationName} to {aggregateType.Name} because {reason}")
    {

    }
}