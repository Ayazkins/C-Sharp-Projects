using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Renderers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowConsoleCommand : ICommand
{
    private readonly string _path;

    public FileShowConsoleCommand(string path)
    {
        _path = path;
    }

    public ITree? Execute(ITree? tree)
    {
        if (tree == null)
        {
            throw new ArgumentException("Do connect before", nameof(tree));
        }

        new ConsoleRenderer().RenderMessage(tree.GetFile(_path).GetFileData());

        return tree;
    }
}