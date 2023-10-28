using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class FailedValidationException : ArgumentException
{
    public FailedValidationException(string message)
        : base(message)
    {
    }

    public FailedValidationException()
    {
    }

    public FailedValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}