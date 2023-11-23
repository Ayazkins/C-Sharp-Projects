using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface IVisitor
{
    string Result { get; }
    string Visit(ITree tree);
}