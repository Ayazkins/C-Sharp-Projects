using System;
using Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Displays;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayAddressee
{
    private readonly IDisplay _display;
    private readonly ConsoleColor _consoleColor;

    public DisplayAddressee(string name, IDisplay display, ConsoleColor color)
    {
        _display = display;
        Name = name;
        _consoleColor = color;
    }

    public string Name { get; }

    public void TakeMessage(Message message)
    {
        _display.ShowMessage(message, _consoleColor);
    }
}