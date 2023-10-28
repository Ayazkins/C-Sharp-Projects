using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NotPositiveValue : ArgumentException
{
    public NotPositiveValue(string message)
        : base(message)
    {
    }

    public NotPositiveValue()
    {
    }

    public NotPositiveValue(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}