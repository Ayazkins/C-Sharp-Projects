using Itmo.ObjectOrientedProgramming.Lab3.MessageReceiver.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class UserAddressee : IAddressee
{
    private readonly IUser _user;

    public UserAddressee(IUser user)
    {
        _user = user;
    }

    public void TakeMessage(Message message)
    {
        _user.TakeMessage(message);
    }
}