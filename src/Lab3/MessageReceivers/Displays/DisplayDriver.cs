using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Displays;

public class DisplayDriver : IDisplayDriver
{
    public DisplayDriver()
    {
        CurMessage = null;
    }

    public ConsoleColor Color { get; private set; }
    public Message? CurMessage { get; private set; }

    public void ChangeColor(ConsoleColor color)
    {
        Color = color;
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void SaveMessage(Message message)
    {
        CurMessage = message;
    }
}