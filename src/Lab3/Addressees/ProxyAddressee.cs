using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class ProxyAddressee : IAddressee
{
    private readonly IAddressee _realAddressee;
    private readonly LevelOfImportance _levelOfImportance;
    private readonly ILogger? _logger;

    public ProxyAddressee(IAddressee realAddressee, LevelOfImportance levelOfImportance, ILogger? logger = null)
    {
        if (realAddressee == null)
        {
            throw new ArgumentNullException(nameof(realAddressee));
        }

        _logger = logger;
        Name = realAddressee.Name;

        _levelOfImportance = levelOfImportance;
        _realAddressee = realAddressee;
    }

    public string Name { get; }

    public void TakeMessage(Message message)
    {
        _logger?.Info(Name, message);

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