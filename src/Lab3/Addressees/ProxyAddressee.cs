using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class ProxyAddressee : IAddressee
{
    private readonly IAddressee _realAddressee;
    private readonly LevelOfImportance _levelOfImportance;

    public ProxyAddressee(IAddressee realAddressee, LevelOfImportance levelOfImportance)
    {
        _levelOfImportance = levelOfImportance;
        _realAddressee = realAddressee ?? throw new ArgumentNullException(nameof(realAddressee));
    }

    public void TakeMessage(Message message)
    {
        if (Filter(message))
        {
            _realAddressee.TakeMessage(message);
        }
    }

    private bool Filter(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return message.MessageLevelOfImportance.Value() <= _levelOfImportance.Value();
    }
}