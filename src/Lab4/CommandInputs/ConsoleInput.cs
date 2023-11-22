using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandInputs;

public class ConsoleInput : ICommandInput
{
    public string[]? GetCommand()
    {
        return Console.ReadLine()?.Split();
    }
}