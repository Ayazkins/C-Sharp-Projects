using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Messengers;

public class Telegram : ITelegram
{
    public void SendMessage(string api, string userId, string message)
    {
        Console.WriteLine("Telegram : " + message);
    }
}