using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class FileDeleteParser : IParser
{
    public IParser? Successor { get; set; }
    public ICommand Parse(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("args can't be empty or null", nameof(args));
        }

        if (string.Equals(args[0], "file", StringComparison.OrdinalIgnoreCase) &&
            string.Equals(args[1], "delete", StringComparison.OrdinalIgnoreCase) &&
            args.Length == 3)
        {
            return new FileDeleteCommand(args[2]);
        }

        if (Successor == null)
        {
            throw new ArgumentException("No such command", nameof(args));
        }

        return Successor.Parse(args);
    }
}