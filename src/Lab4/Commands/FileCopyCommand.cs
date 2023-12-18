using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopyCommand : ICommand
{
    private readonly string _source;
    private readonly string _destination;

    public FileCopyCommand(string source, string destination)
    {
        _source = source;
        _destination = destination;
    }

    public ITree? Execute(ITree? tree)
    {
        if (tree == null)
        {
            throw new ArgumentException("Do connect before", nameof(tree));
        }

        tree.GetFile(_source).CloneTo(_destination, tree);
        return tree;
    }
}