using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectLocalCommand : ICommand
{
    private readonly string _address;

    public ConnectLocalCommand(string address)
    {
        _address = address;
    }

    public ITree? Execute(ITree? tree)
    {
        return new LocalTree(_address);
    }
}