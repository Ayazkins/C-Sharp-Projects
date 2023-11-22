using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class TreeShowParser : IParser
{
    public IParser? Successor { get; set; }

    public ICommand Parse(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("args can't be empty or null", nameof(args));
        }

        if (args.Length == 5 &&
            string.Equals(args[0], "tree", StringComparison.OrdinalIgnoreCase) &&
            string.Equals(args[1], "show", StringComparison.OrdinalIgnoreCase))
        {
            return new TreeShowCommand(args[2], args[3], args[4]);
        }

        if (Successor == null)
        {
            throw new ArgumentException("No such command", nameof(args));
        }

        return Successor.Parse(args);
    }
}