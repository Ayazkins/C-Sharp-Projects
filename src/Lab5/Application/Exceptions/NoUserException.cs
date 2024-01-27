namespace Application.Exceptions;

public class NoUserException : ArgumentException
{
    public NoUserException(string message)
        : base(message)
    {
    }

    public NoUserException()
    {
    }

    public NoUserException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}