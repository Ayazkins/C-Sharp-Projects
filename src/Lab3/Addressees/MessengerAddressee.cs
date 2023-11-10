using Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class MessengerAddressee : IAddressee
{
    private readonly IMessenger _messenger;

    public MessengerAddressee(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void TakeMessage(Message message)
    {
        SendMessage(message);
    }

    public void SendMessage(Message message)
    {
        _messenger.SendMessage(message);
    }
}