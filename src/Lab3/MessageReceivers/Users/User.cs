using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageReceiver.Users;

public class User : IUser
{
    private readonly List<UserMessage> _messages;

    public User(string name)
    {
        _messages = new List<UserMessage>();
        Name = name;
    }

    public string Name { get; }

    public void TakeMessage(Message message)
    {
        _messages.Add(new UserMessage(message));
    }

    public void ReadMessage(int index)
    {
        if (!_messages[index].ReadMessage())
        {
            throw new MessageIsReadAlreadyException();
        }
    }

    public IReadOnlyCollection<UserMessage> CopyOfMessages()
    {
        return new List<UserMessage>(_messages);
    }
}