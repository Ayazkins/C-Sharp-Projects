using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class LoggerAddOn : IAddressee
{
    private readonly ILogger _logger;
    private IAddressee _addressee;

    public LoggerAddOn(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void TakeMessage(Message message)
    {
        _logger.Info(message);
        _addressee.TakeMessage(message);
    }
}