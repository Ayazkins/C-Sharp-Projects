using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Files;

namespace Itmo.ObjectOrientedProgramming.Lab4.Directories;

public class Directory : IDirectory
{
    public Directory(string directoryPath, IDirectory? directory)
    {
        DirectoryPath = directoryPath;
        Files = new List<IFile>();
        Directories = new List<IDirectory>();
        Parent = directory;
    }

    public IList<IFile> Files { get; }
    public IList<IDirectory> Directories { get; }
    public IDirectory? Parent { get; }
    public string DirectoryPath { get; }

    public void AddDirectory(IDirectory directory)
    {
        Directories.Add(directory);
    }

    public void AddFile(IFile file)
    {
        Files.Add(file);
    }

    public void DeleteFile(IFile file)
    {
        Files.Remove(file);
    }

    public IFile GetFile(string path)
    {
        IFile? file = Files.FirstOrDefault(file => file?.FilePath == path, null)
                      ?? throw new ArgumentException("No such file", nameof(path));
        return file;
    }

    public string GetName()
    {
        return DirectoryPath.Split(Path.DirectorySeparatorChar).Last();
    }
}