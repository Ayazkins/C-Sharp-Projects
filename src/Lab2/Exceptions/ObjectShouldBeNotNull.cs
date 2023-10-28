using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ObjectShouldBeNotNull : ArgumentException
{
    public ObjectShouldBeNotNull(string message)
        : base(message)
    {
    }

    public ObjectShouldBeNotNull()
    {
    }

    public ObjectShouldBeNotNull(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}