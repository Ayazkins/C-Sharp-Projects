using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;

    public FileRenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public ITree? Execute(ITree? tree)
    {
        if (tree == null)
        {
            throw new ArgumentException("Do connect before", nameof(tree));
        }

        tree.GetFile(_path).RenameTo(_name);
        return tree;
    }
}