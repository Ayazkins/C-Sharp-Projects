using Itmo.ObjectOrientedProgramming.Lab4.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.Files;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface ITree
{
    IDirectory Root { get; }
    IDirectory Current { get; set; }

    int Depth { get; set; }
    IDirectory Go(string path);

    IFile GetFile(string path);
}