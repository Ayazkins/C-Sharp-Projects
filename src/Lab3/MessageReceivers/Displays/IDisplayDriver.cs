using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Displays;

public interface IDisplayDriver
{
    Message? CurMessage { get; }
    ConsoleColor Color { get; }
    void ChangeColor(ConsoleColor color);
    void Clear();
    void SaveMessage(Message message);
}