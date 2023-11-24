using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Renderers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeShowCommand : ICommand
{
    private readonly string _folder;
    private readonly string _file;
    private readonly string _space;

    public TreeShowCommand(string folder, string file, string s)
    {
        _folder = folder;
        _file = file;
        _space = s;
    }

    public ITree? Execute(ITree? tree)
    {
        if (tree == null)
        {
            throw new ArgumentException("Do connect before", nameof(tree));
        }

        new ConsoleRenderer(new Visitor()).RenderTree(tree, _folder, _file, _space);
        return tree;
    }
}