using System;
using Itmo.ObjectOrientedProgramming.Lab4.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.Files;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Renderers;

public class ConsoleRenderer : IRenderer
{
    private readonly string _folderSymbol;
    private readonly string _fileSymbol;
    private readonly string _spaceSymbol;

    public ConsoleRenderer()
    {
        _folderSymbol = "*";
        _fileSymbol = ".";
        _spaceSymbol = "   ";
    }

    public void RenderTree(ITree tree, string folder, string file, string space)
    {
        if (tree == null)
        {
            throw new ArgumentException("Tree should be connected", nameof(tree));
        }

        RenderMessage(folder + " " + tree.Root.GetName());

        ShowRec(tree.Root, folder, file, space, 0, tree.Depth);
    }

    public void RenderTree(ITree tree)
    {
        RenderTree(tree, _folderSymbol, _fileSymbol, _spaceSymbol);
    }

    public void RenderMessage(string message)
    {
        Console.WriteLine(message);
    }

    private void ShowRec(IDirectory directory, string folder, string file, string space, int curDepth, int depth)
    {
        if (depth <= curDepth)
        {
            return;
        }

        foreach (IDirectory dir in directory.Directories)
        {
            RenderMessage(space + folder + " " + dir.GetName());
            ShowRec(dir, folder, file, space + space, curDepth += 1, depth);
        }

        foreach (IFile dir in directory.Files)
        {
            RenderMessage(space + file + " " + dir.GetName());
        }
    }
}