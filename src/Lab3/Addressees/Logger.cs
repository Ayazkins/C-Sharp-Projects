using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class Logger : ILogger
{
    public void Info(string addresseeName, Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        Console.WriteLine(DateTime.Now + " Addressee name : " + addresseeName + " Message : " + message.Title + " " +
                          message.MessageBody);
    }
}