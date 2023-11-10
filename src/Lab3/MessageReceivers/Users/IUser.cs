using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageReceiver.Users;

public interface IUser
{
    string Name { get; }
    void TakeMessage(Message message);
}