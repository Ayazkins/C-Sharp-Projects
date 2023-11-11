using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class UserMessage
{
    public UserMessage(Message message)
    {
        MessageReceived = message ?? throw new ArgumentNullException(nameof(message));
        IsRead = false;
    }

    public bool IsRead { get; private set; }
    public Message MessageReceived { get; }

    public bool ReadMessage()
    {
        if (IsRead)
        {
            return false;
        }

        IsRead = true;
        return true;
    }
}