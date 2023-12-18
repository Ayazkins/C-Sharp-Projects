using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class TreeGotoParser : IParser
{
    public IParser? Successor { get; set; }

    public ICommand Parse(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("args can't be empty or null", nameof(args));
        }

        if (string.Equals(args[0], "tree", StringComparison.OrdinalIgnoreCase) &&
            string.Equals(args[1], "goto", StringComparison.OrdinalIgnoreCase) &&
            args.Length == 3)
        {
            return new TreeGotoCommand(args[2]);
        }

        if (Successor == null)
        {
            throw new ArgumentException("No such command", nameof(args));
        }

        return Successor.Parse(args);
    }
}