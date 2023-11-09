using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageLogs;
using Itmo.ObjectOrientedProgramming.Lab3.Recievers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class TestCases
{
    [Fact]
    public void Test1()
    {
        UserReciever user = Substitute.For<UserReciever>();
        var adressee = new BaseAddressee(user, Logger.TakeInstance());
        var topic = new Topic("TestTopic", adressee);

        var message = new Message("test", Priorities.TopSecret);
        topic.Recieve(message);

        user.Received(1).Recieve(message);
        Assert.False(user.IsRead(message));
    }

    [Fact]
    public void Test2()
    {
        var user = new UserReciever();
        var adressee = new BaseAddressee(user, Logger.TakeInstance());
        var topic = new Topic("TestTopic", adressee);

        var message = new Message("test", Priorities.TopSecret);
        topic.Recieve(message);
        user.ReadMessage(message);

        Assert.True(user.IsRead(message));
    }

    [Fact]
    public void Test3()
    {
        var user = new UserReciever();
        var adressee = new BaseAddressee(user, Logger.TakeInstance());
        var topic = new Topic("TestTopic", adressee);

        var message = new Message("test", Priorities.TopSecret);
        topic.Recieve(message);
        user.ReadMessage(message);

        Assert.Throws<AlreadyReadException>(() =>
        {
            user.ReadMessage(message);
        });
    }

    [Fact]
    public void Test4()
    {
        UserReciever user = Substitute.For<UserReciever>();
        ILogger logger = Logger.TakeInstance();
        var adressee = new BaseAddressee(user, logger, Priorities.Open);
        var topic = new Topic("TestTopic", adressee);

        var message = new Message("test", Priorities.Secret);
        topic.Recieve(message);

        user.Received(0).Recieve(message);
    }

    [Fact]
    public void Test5()
    {
        MessangerReciever? user = Substitute.For<MessangerReciever>();
        ILogger logger = Logger.TakeInstance();
        var adressee = new BaseAddressee(user, logger);
        var topic = new Topic("TestTopic", adressee);

        var message = new Message("test", Priorities.Secret);
        topic.Recieve(message);

        user.Received(1).Recieve(message);
    }
}