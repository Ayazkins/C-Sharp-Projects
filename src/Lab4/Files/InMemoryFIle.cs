using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public class InMemoryFIle : IFile
{
    public InMemoryFIle(string path, IDirectory parent)
    {
        FilePath = path;
        Parent = parent;
    }

    public string FilePath { get; private set; }
    public IDirectory Parent { get; }

    public string GetFileData()
    {
        return string.Empty;
    }

    public string GetName()
    {
        return FilePath.Split(Path.DirectorySeparatorChar).Last();
    }

    public void CloneTo(string path, ITree tree)
    {
        if (tree == null)
        {
            throw new ArgumentNullException(nameof(tree));
        }

        IDirectory directory = tree.Go(path);
        directory.AddFile(
            new InMemoryFIle(directory.DirectoryPath + Path.DirectorySeparatorChar + GetName(), directory));
    }

    public void Delete()
    {
        Parent.DeleteFile(this);
    }

    public void MoveTo(string path, ITree tree)
    {
        CloneTo(path, tree);
        Delete();
    }

    public void RenameTo(string newName)
    {
        string[] args = FilePath.Split(Path.DirectorySeparatorChar);
        args[^1] = newName;
        string? newPath = string.Join(Path.DirectorySeparatorChar, args) ??
                          throw new ArgumentException("Can't make new path", nameof(newName));
        FilePath = newPath;
    }
}