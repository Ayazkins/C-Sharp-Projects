using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Renderers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowConsoleCommand : ICommand
{
    private readonly string _path;
    private readonly string _mode;

    public FileShowConsoleCommand(string path, string mode)
    {
        _path = path;
        _mode = mode;
    }

    public ITree? Execute(ITree? tree)
    {
        if (tree == null)
        {
            throw new ArgumentException("Do connect before", nameof(tree));
        }

        if (_mode == "local")
        {
            new ConsoleRenderer().RenderMessage(tree.GetFile(_path).GetFileData());
        }

        return tree;
    }
}