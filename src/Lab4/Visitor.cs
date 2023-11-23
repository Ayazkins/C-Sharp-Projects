using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.Files;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Visitor : IVisitor
{
    private readonly string _folderSymbol;
    private readonly string _fileSymbol;
    private readonly string _spaceSymbol;

    public Visitor()
    {
        _folderSymbol = "*";
        _fileSymbol = ".";
        _spaceSymbol = "   ";
        Result = string.Empty;
    }

    public Visitor(string folder, string file, string space)
    {
        _folderSymbol = folder;
        _fileSymbol = file;
        _spaceSymbol = space;
        Result = string.Empty;
    }

    public string Result { get; set; }

    public string Visit(ITree tree)
    {
        if (tree == null)
        {
            throw new ArgumentNullException(nameof(tree));
        }

        return ShowRec(tree.Root, _folderSymbol, _fileSymbol, _spaceSymbol, 0, tree.Depth, new StringBuilder())
            .ToString();
    }

    private StringBuilder ShowRec(
        IDirectory directory,
        string folder,
        string file,
        string space,
        int curDepth,
        int depth,
        StringBuilder stringBuilder)
    {
        if (depth <= curDepth)
        {
            return stringBuilder;
        }

        foreach (IDirectory dir in directory.Directories)
        {
            stringBuilder.Append(space + folder + " " + dir.GetName() + "\n");
            ShowRec(dir, folder, file, space + space, curDepth += 1, depth, stringBuilder);
        }

        foreach (IFile dir in directory.Files)
        {
            stringBuilder.Append(space + file + " " + dir.GetName() + "\n");
        }

        return stringBuilder;
    }
}