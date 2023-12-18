using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Renderers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    public TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public ITree? Execute(ITree? tree)
    {
        if (tree == null)
        {
            throw new ArgumentException("Do connect before", nameof(tree));
        }

        tree.Depth = _depth;
        new ConsoleRenderer(new Visitor()).RenderTree(tree);
        return tree;
    }
}