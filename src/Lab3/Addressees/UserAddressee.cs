using Itmo.ObjectOrientedProgramming.Lab3.MessageReceiver.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class UserAddressee : IAddressee
{
    private readonly IUser _user;

    public UserAddressee(string name, IUser user)
    {
        _user = user;
        Name = name;
    }

    public string Name { get; }

    public void TakeMessage(Message message)
    {
        _user.TakeMessage(message);
    }
}