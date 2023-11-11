using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MessageIsReadAlreadyException : Exception
{
    public MessageIsReadAlreadyException(string message)
        : base(message)
    {
    }

    public MessageIsReadAlreadyException()
    {
    }

    public MessageIsReadAlreadyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
