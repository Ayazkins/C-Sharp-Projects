using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectInMemoryCommand : ICommand
{
    public ConnectInMemoryCommand()
    {
    }

    public ITree? Execute(ITree? tree)
    {
        return tree;
    }
}