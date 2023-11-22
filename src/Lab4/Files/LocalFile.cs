using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public class LocalFile : IFile
{
    public LocalFile(string filePath, IDirectory directory)
    {
        FilePath = filePath;
        Parent = directory;
    }

    public string FilePath { get; private set; }
    public IDirectory Parent { get; private set; }

    public string GetFileData()
    {
        var file = new StreamReader(FilePath);
        string message = file.ReadToEnd();
        file.Close();
        return message;
    }

    public void CloneTo(string path, ITree tree)
    {
        if (tree == null)
        {
            throw new ArgumentNullException(nameof(tree));
        }

        File.Create(path + GetName()).Dispose();
        File.Copy(FilePath, path + Path.DirectorySeparatorChar + GetName());
        IDirectory directory = tree.Go(path);
        directory.AddFile(
            new LocalFile(directory.DirectoryPath + Path.DirectorySeparatorChar + GetName(), directory));
    }

    public void Delete()
    {
        IDirectory parent = Parent;
        parent.DeleteFile(this);
        var fileInf = new FileInfo(FilePath);
        fileInf.Delete();
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
        File.Move(FilePath, newPath);
        FilePath = newPath;
    }

    public string GetName()
    {
        return FilePath.Split(Path.DirectorySeparatorChar).Last();
    }
}