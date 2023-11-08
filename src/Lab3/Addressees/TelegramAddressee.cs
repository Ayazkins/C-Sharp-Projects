using Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class TelegramAddressee : IAddressee, IMessenger
{
    private readonly string _userId;
    private readonly ITelegram _telegram;

    public TelegramAddressee(string name, string userId, ITelegram telegram)
    {
        Name = name;
        _userId = userId;
        _telegram = telegram;
    }

    public string Name { get; }

    public void TakeMessage(Message message)
    {
        SendMessage(message);
    }

    public void SendMessage(Message message)
    {
        if (message == null)
        {
            return;
        }

        _telegram.SendMessage(string.Empty, _userId, message.MessageBody);
    }
}