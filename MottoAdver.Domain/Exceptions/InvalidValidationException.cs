namespace MottoAdver.Domain.Exceptions;

public class InvalidValidationException : Exception
{
    public InvalidValidationException(string message) 
        : base(message)
    {
    }
}
