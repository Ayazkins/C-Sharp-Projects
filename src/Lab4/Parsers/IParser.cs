using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public interface IParser
{
    IParser? Successor { get; set; }
    ICommand Parse(string[] args);
}