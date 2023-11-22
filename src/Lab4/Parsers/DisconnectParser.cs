using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class DisconnectParser : IParser
{
    public IParser? Successor { get; set; }

    public ICommand Parse(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("args can't be empty or null", nameof(args));
        }

        if (args.Length == 1 && string.Equals(args[0], "disconnect", StringComparison.OrdinalIgnoreCase))
        {
            return new DisconnectCommand();
        }

        if (Successor == null)
        {
            throw new ArgumentException("No such command", nameof(args));
        }

        return Successor.Parse(args);
    }
}