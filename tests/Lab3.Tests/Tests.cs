using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Facades;
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
    private readonly IFacade _facade;
    private readonly User _user;

    public Tests()
    {
        _mockAddressee = new Mock<IAddressee>();
        _mockLogger = new Mock<ILogger>();
        _facade = new Facade();
        _user = new User("me");
        IAddressee userAddressee = new UserAddressee(_user);
        var topic = new Topic("user check", userAddressee);
        _facade.Add(topic);
        IAddressee proxy = new ProxyAddressee(userAddressee, new LevelOfImportance.SecondLevelOfImportance());
        var levelOfImportanceTestTopic = new Topic("Level of importance", proxy);
        _facade.Add(levelOfImportanceTestTopic);
        var proxy2 = new LoggerAddOn(
            new ProxyAddressee(
                userAddressee,
                new LevelOfImportance.ThirdLevelOfImportance()),
            _mockLogger.Object);
        var loggerTestTopic = new Topic("Logger", proxy2);
        _facade.Add(loggerTestTopic);
        var mockTelegram = new Mock<ITelegram>();
        var messenger = new MessengerAddressee(new TelegramAdapter(mockTelegram.Object, "me"));
        var proxy3 = new LoggerAddOn(
            new ProxyAddressee(
                messenger,
                new LevelOfImportance.ThirdLevelOfImportance()),
            _mockLogger.Object);
        var messengerTestTopic = new Topic("Messenger", proxy3);
        _facade.Add(messengerTestTopic);
    }

    [Fact]
    public void UserTakesMessageTest()
    {
        var message = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());
        var message2 = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());

        _facade.SendMessage("user check", message);
        _facade.SendMessage("user check", message2);

        IReadOnlyCollection<UserMessage> userMessages = _user.CopyOfMessages();
        foreach (UserMessage userMessage in userMessages)
        {
            Assert.False(userMessage.IsRead);
        }
    }

    [Fact]
    public void UserReadMessageTest()
    {
        var message = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());
        var message2 = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());
        _facade.SendMessage("user check", message);
        _facade.SendMessage("user check", message2);

        _user.ReadMessage(0);

        IReadOnlyCollection<UserMessage> userMessages = _user.CopyOfMessages();
        using IEnumerator<UserMessage> iterator = userMessages.GetEnumerator();
        iterator.MoveNext();
        Assert.True(iterator.Current.IsRead);
        iterator.MoveNext();
        Assert.False(iterator.Current.IsRead);
    }

    [Fact]
    public void UserReadTwiceMessageTest()
    {
        var message = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());
        var message2 = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());

        _facade.SendMessage("user check", message);
        _facade.SendMessage("user check", message2);
        _user.ReadMessage(0);

        Assert.Throws<MessageIsReadAlreadyException>(() => _user.ReadMessage(0));
    }

    [Fact]
    public void LevelOfImportanceTest()
    {
        var message = new Message("Test", "Hello", new LevelOfImportance.ThirdLevelOfImportance());

        _facade.SendMessage("Level of importance", message);

        _mockAddressee.Verify(a => a.TakeMessage(message), Times.Never);
    }

    [Fact]
    public void LoggerTest()
    {
        var message = new Message("Test", "Hello", new LevelOfImportance.FirstLevelOfImportance());

        _facade.SendMessage("Logger", message);

        _mockLogger.Verify(a => a.Info(message), Times.Once);
    }

    [Fact]
    public void MessengerTest()
    {
        var message = new Message("Test", "Hello", new LevelOfImportance.FirstLevelOfImportance());

        _facade.SendMessage("Messenger", message);

        _mockLogger.Verify(a => a.Info(message), Times.Once);
    }
}