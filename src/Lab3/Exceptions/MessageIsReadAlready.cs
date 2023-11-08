using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MessageIsReadAlready : ArgumentException
{
    public MessageIsReadAlready(string message)
        : base(message)
    {
    }

    public MessageIsReadAlready()
    {
    }

    public MessageIsReadAlready(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
