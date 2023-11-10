using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class GroupAddressee : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _addressees;

    public GroupAddressee(IReadOnlyCollection<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void TakeMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.TakeMessage(message);
        }
    }
}