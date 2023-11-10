using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Displays;

public interface IDisplay
{
    string Name { get; }
    void ShowMessage(Message message, ConsoleColor color);
}