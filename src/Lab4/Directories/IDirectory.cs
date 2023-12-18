using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Files;

namespace Itmo.ObjectOrientedProgramming.Lab4.Directories;

public interface IDirectory
{
    IList<IFile> Files { get; }
    IList<IDirectory> Directories { get; }
    IDirectory? Parent { get; }
    string DirectoryPath { get; }

    void AddDirectory(IDirectory directory);
    void AddFile(IFile file);
    void DeleteFile(IFile file);
    IFile GetFile(string path);

    string GetName();
}