using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class TreeListParser : IParser
{
    public IParser? Successor { get; set; }

    public ICommand Parse(string[] args)
    {
        if (args == null || args.Length == 0)
        {
            throw new ArgumentException("args can't be empty or null", nameof(args));
        }

        if (string.Equals(args[0], "tree", StringComparison.OrdinalIgnoreCase) &&
            string.Equals(args[1], "list", StringComparison.OrdinalIgnoreCase))
        {
            switch (args.Length)
            {
                case 2:
                    return new TreeListCommand(1);
                case 4:
                    return new TreeListCommand(int.Parse(args[3], NumberStyles.Integer, new NumberFormatInfo()));
            }
        }

        if (Successor == null)
        {
            throw new ArgumentException("No such command", nameof(args));
        }

        return Successor.Parse(args);
    }
}