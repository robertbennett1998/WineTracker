namespace WineTracker.Wine.Service.Domain.Exceptions;

public abstract class DomainException : Exception
{
    private static string ToDomainExceptionMessage(string? message) =>
        message is null ? 
            "A Wine Domain Exception occured" : 
            $"Wine Domain Exception: {message}"; 
    
    protected DomainException(string? message) : base(ToDomainExceptionMessage(message))
    {
    }
    
    protected DomainException(string? message, Exception? innerException) : base(ToDomainExceptionMessage(message), innerException)
    {
    }
}