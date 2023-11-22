using Itmo.ObjectOrientedProgramming.Lab4.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public interface IFile
{
    string FilePath { get; }
    IDirectory Parent { get; }
    string GetFileData();

    string GetName();
    void CloneTo(string path, ITree tree);

    void Delete();

    void MoveTo(string path, ITree tree);

    void RenameTo(string newName);
}