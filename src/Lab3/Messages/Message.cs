using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Message
{
    public Message(string title, string messageBody, LevelOfImportance messageLevelOfImportance)
    {
        Title = title;
        MessageBody = messageBody;
        MessageLevelOfImportance = messageLevelOfImportance;
    }

    public string Title { get; }
    public string MessageBody { get; }
    public LevelOfImportance MessageLevelOfImportance { get; }
}