using System;
using Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayAddressee : IAddressee
{
    private readonly IDisplay _display;
    private readonly ConsoleColor _consoleColor;

    public DisplayAddressee(IDisplay display, ConsoleColor color)
    {
        _display = display;
        _consoleColor = color;
    }

    public void TakeMessage(Message message)
    {
        _display.ShowMessage(message, _consoleColor);
    }
}