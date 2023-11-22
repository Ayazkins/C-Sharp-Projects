using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class FileShowConcoleParser : IParser
{
    public IParser? Successor { get; set; }

    public ICommand Parse(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("args can't be empty or null", nameof(args));
        }

        if (args.Length == 5 &&
            string.Equals(args[0], "file", StringComparison.OrdinalIgnoreCase) &&
            string.Equals(args[1], "show", StringComparison.OrdinalIgnoreCase) &&
            string.Equals(args[3], "-m", StringComparison.OrdinalIgnoreCase) &&
            string.Equals(args[4], "console", StringComparison.OrdinalIgnoreCase))
        {
            return new FileShowConsoleCommand(args[2]);
        }

        if (Successor == null)
        {
            throw new ArgumentException("No such command", nameof(args));
        }

        return Successor.Parse(args);
    }
}