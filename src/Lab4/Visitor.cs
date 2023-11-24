using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.Files;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Visitor : IVisitor
{
    public Visitor()
    {
        Result = string.Empty;
    }

    public string Result { get; set; }

    public void Visit(ITree tree, string folderSymbol, string fileSymbol, string spaceSymbol)
    {
        if (tree == null)
        {
            throw new ArgumentNullException(nameof(tree));
        }

        Result = ShowRec(tree.Root, folderSymbol, fileSymbol, spaceSymbol, 0, tree.Depth, new StringBuilder())
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