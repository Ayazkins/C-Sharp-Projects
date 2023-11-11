using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Messengers;

public class TelegramAdapter : IMessenger
{
    private readonly string _user;
    private ITelegram _telegram;

    public TelegramAdapter(ITelegram telegram, string user)
    {
        _telegram = telegram;
        _user = user;
    }

    public void SendMessage(Message message)
    {
        if (message == null)
        {
            return;
        }

        _telegram.SendMessage(string.Empty, _user, message.MessageBody);
    }
}