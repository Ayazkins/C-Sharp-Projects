using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    public ITree? Tree { get; set; }

    public ITree? Execute(ITree? tree)
    {
        return null;
    }
}