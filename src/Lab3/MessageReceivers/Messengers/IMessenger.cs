using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Messengers;

public interface IMessenger
{
    void SendMessage(Message message);
}