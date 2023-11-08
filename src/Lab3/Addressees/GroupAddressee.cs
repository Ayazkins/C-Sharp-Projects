using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class GroupAddressee : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _addressees;

    public GroupAddressee(IReadOnlyCollection<IAddressee> addressees, string name)
    {
        Name = name;
        _addressees = addressees;
    }

    public string Name { get; }

    public void TakeMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.TakeMessage(message);
        }
    }
}