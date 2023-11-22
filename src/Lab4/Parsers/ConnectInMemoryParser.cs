using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class ConnectInMemoryParser : IParser
{
    public IParser? Successor { get; set; }

    public ICommand Parse(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("args can't be empty or null", nameof(args));
        }

        if (args.Length == 4 &&
            string.Equals(args[0], "connect", StringComparison.OrdinalIgnoreCase) &&
            string.Equals(args[2], "-m", StringComparison.OrdinalIgnoreCase) &&
            string.Equals(args[3], "inmemory", StringComparison.OrdinalIgnoreCase))
        {
            return new ConnectInMemoryCommand();
        }

        if (Successor == null)
        {
            throw new ArgumentException("No such command", nameof(args));
        }

        return Successor.Parse(args);
    }
}