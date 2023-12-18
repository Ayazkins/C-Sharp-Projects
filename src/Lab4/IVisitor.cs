using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface IVisitor
{
    string Result { get; }
    void Visit(ITree tree, string folderSymbol, string fileSymbol, string spaceSymbol);
}