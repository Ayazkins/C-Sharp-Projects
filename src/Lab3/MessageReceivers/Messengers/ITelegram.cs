namespace Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Messengers;

public interface ITelegram
{
    void SendMessage(string api, string userId, string message);
}