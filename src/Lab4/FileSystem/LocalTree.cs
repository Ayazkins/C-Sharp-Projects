using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.Files;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Directories.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class LocalTree : ITree
{
    public LocalTree(string path)
    {
        Root = new Directory(path, null);
        Current = Root;
        Depth = 1;
        InitTree(Root);
    }

    public IDirectory Root { get; }
    public IDirectory Current { get; set; }
    public int Depth { get; set; }

    public IDirectory Go(string path)
    {
        if (path == null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        IDirectory? target;
        string[] pathArray = path.Split(Path.DirectorySeparatorChar);
        int start = 0;
        if (IsAbsolute(path))
        {
            start = Array.IndexOf(pathArray, Root.GetName());
            target = Root;
        }
        else
        {
            target = Current;
        }

        target = FindDown(pathArray, target, start);
        if (start == -1 || target == null)
        {
            throw new ArgumentException("Wrong path", nameof(path));
        }

        Current = target;

        return target;
    }

    public IFile GetFile(string path)
    {
        if (path == null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        IDirectory? target;
        string[] pathArray = path.Split(Path.DirectorySeparatorChar);
        int start = 0;

        if (IsAbsolute(path))
        {
            target = Root;
            start = Array.IndexOf(pathArray, Root.GetName());
        }
        else
        {
            target = Current;
        }

        string[] temp = pathArray.Take(pathArray.Length - 1).ToArray();

        target = FindDown(temp, target, start);
        if (target == null)
        {
            throw new ArgumentException("Wrong path", nameof(path));
        }

        IFile? file = target.Files.FirstOrDefault(obj => obj?.GetName() == pathArray.Last(), null);
        if (file == null)
        {
            throw new ArgumentException("Wrong path", nameof(path));
        }

        return file;
    }

    private void InitTree(IDirectory directory)
    {
        if (directory == null)
        {
            throw new ArgumentNullException(nameof(directory));
        }

        string[] files = System.IO.Directory.GetFiles(directory.DirectoryPath);
        foreach (string s in files)
        {
            directory.AddFile(new LocalFile(s, directory));
        }

        string[] directories = System.IO.Directory.GetDirectories(directory.DirectoryPath);

        foreach (string s in directories)
        {
            var dir = new Directory(s, directory);
            directory.AddDirectory(dir);
            InitTree(dir);
        }
    }

    private bool IsAbsolute(string path)
    {
        return path.StartsWith(Root.DirectoryPath, StringComparison.OrdinalIgnoreCase);
    }

    private IDirectory? FindDown(string[] pathArray, IDirectory target, int start)
    {
        for (int i = start + 1; i < pathArray.Length; ++i)
        {
            IDirectory? temp = target.Directories.FirstOrDefault(obj => obj?.GetName() == pathArray[i], null);
            if (temp != null)
            {
                target = temp;
            }
            else
            {
                return null;
            }
        }

        return target;
    }
}