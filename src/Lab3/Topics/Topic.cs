using Itmo.ObjectOrientedProgramming.Lab3.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    public Topic(string name, IAddressee topicAddressee)
    {
        Name = name;
        TopicAddressee = topicAddressee;
    }

    private string Name { get; }
    private IAddressee TopicAddressee { get; }

    public void TakeMessage(Message message)
    {
        TopicAddressee.TakeMessage(message);
    }
}