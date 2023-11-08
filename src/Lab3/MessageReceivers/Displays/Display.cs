using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        Name = "Display";
        _displayDriver = displayDriver;
    }

    public string Name { get; }

    public void ShowMessage(Message message, ConsoleColor color)
    {
        _displayDriver.SaveMessage(message);
        _displayDriver.ChangeColor(color);
        _displayDriver.Clear();
        Console.WriteLine(_displayDriver.CurMessage + " " + _displayDriver.CurMessage);
    }
}