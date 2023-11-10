using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class Logger : ILogger
{
    public void Info(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        Console.WriteLine(DateTime.Now + " Message : " + message.Title + " " +
                          message.MessageBody);
    }
}