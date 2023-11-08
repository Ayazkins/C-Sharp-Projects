using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.MessageReceiver.Users;
using Itmo.ObjectOrientedProgramming.Lab3.MessageReceivers.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Tests
{
    private readonly Mock<IAddressee> _mockAddressee;
    private readonly Mock<ILogger> _mockLogger;

    public Tests()
    {
        _mockAddressee = new Mock<IAddressee>();
        _mockLogger = new Mock<ILogger>();
    }

    [Fact]
    public void UserTakesMessageTest()
    {
        var user = new User("me");
        IAddressee userAddressee = new UserAddressee("user addressee", user);
        var topic = new Topic("user check", userAddressee);
        var message = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());
        var message2 = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());

        topic.TakeMessage(message);
        topic.TakeMessage(message2);

        IReadOnlyCollection<UserMessage> userMessages = user.CopyOfMessages();
        foreach (UserMessage userMessage in userMessages)
        {
            Assert.False(userMessage.IsRead);
        }
    }

    [Fact]
    public void UserReadMessageTest()
    {
        var user = new User("me");
        IAddressee userAddressee = new UserAddressee("user addressee", user);
        var topic = new Topic("user check", userAddressee);
        var message = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());
        var message2 = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());

        topic.TakeMessage(message);
        topic.TakeMessage(message2);
        user.ReadMessage(0);

        IReadOnlyCollection<UserMessage> userMessages = user.CopyOfMessages();
        IEnumerator<UserMessage> iterator = userMessages.GetEnumerator();
        iterator.MoveNext();
        Assert.True(iterator.Current.IsRead);
        iterator.MoveNext();
        Assert.False(iterator.Current.IsRead);
    }

    [Fact]
    public void UserReadTwiceMessageTest()
    {
        var user = new User("me");
        IAddressee userAddressee = new UserAddressee("user addressee", user);
        var topic = new Topic("user check", userAddressee);
        var message = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());
        var message2 = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());

        topic.TakeMessage(message);
        topic.TakeMessage(message2);
        user.ReadMessage(0);

        Assert.Throws<MessageIsReadAlready>(() => user.ReadMessage(0));
    }

    [Fact]
    public void LevelOfImportanceTest()
    {
        var user = new User("me");
        IAddressee userAddressee = new UserAddressee("user addressee", user);
        IAddressee proxy = new ProxyAddressee(userAddressee, new LevelOfImportance.SecondLevelOfImportance());
        var topic = new Topic("user check", proxy);
        var message = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());

        topic.TakeMessage(message);

        _mockAddressee.Verify(a => a.TakeMessage(message), Times.Never);
    }

    [Fact]
    public void LoggerTest()
    {
        var user = new User("me");
        IAddressee userAddressee = new UserAddressee("user addressee", user);
        var proxy = new ProxyAddressee(userAddressee, new LevelOfImportance.ThirdLevelOfImportance(), _mockLogger.Object);
        var topic = new Topic("user check", proxy);
        var message = new Message("Test", "Hello", new LevelOfImportance.FirstLevelOfImportance());

        topic.TakeMessage(message);

        _mockLogger.Verify(a => a.Info(proxy.Name, message), Times.Once);
    }

    [Fact]
    public void MessengerTest()
    {
        var mockTelegram = new Mock<ITelegram>();
        var messenger = new TelegramAddressee("Telegram", "1", mockTelegram.Object);
        var proxy = new ProxyAddressee(messenger, new LevelOfImportance.ThirdLevelOfImportance(), _mockLogger.Object);
        var topic = new Topic("user check", proxy);
        var message = new Message("Test", "Hello", new LevelOfImportance.FirstLevelOfImportance());

        topic.TakeMessage(message);

        _mockLogger.Verify(a => a.Info(proxy.Name, message), Times.Once);
    }
}