using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;

namespace Itmo.ObjectOrientedProgramming.Lab3.Facades;

public interface IFacade
{
    public void Add(Topic topic);

    public void SendMessage(string name, Message message);

    public void Remove(string name);
}