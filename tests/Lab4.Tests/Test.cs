using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Test
{
    [Fact]
    public void ConnectTest()
    {
        var command = new Command("connect 'C:\\Program Files'");
        LocalFileSystem fileSystem = Substitute.For<LocalFileSystem>();

        var context = new CommandContext(command, fileSystem);

        IHandler chain = new ConnectHandler()
            .AddNext(new DisconnectHandler())
            .AddNext(new TreeHandler())
            .AddNext(new FileHandler());

        chain.Handle(context);

        fileSystem.Received(1).Connect("C:\\Program Files");
    }

    [Fact]
    public void GotoTest()
    {
        LocalFileSystem fileSystem = Substitute.For<LocalFileSystem>();

        IHandler chain = new ConnectHandler()
            .AddNext(new DisconnectHandler())
            .AddNext(new TreeHandler())
            .AddNext(new FileHandler());

        var command = new Command("tree goto Git");
        var context = new CommandContext(command, fileSystem);

        chain.Handle(context);

        fileSystem.Received(1).ChangeDirectory("Git");
    }

    [Fact]
    public void CopyTest()
    {
        LocalFileSystem fileSystem = Substitute.For<LocalFileSystem>();

        IHandler chain = new ConnectHandler()
            .AddNext(new DisconnectHandler())
            .AddNext(new TreeHandler())
            .AddNext(new FileHandler());

        var command = new Command("file copy Test1 Test2");
        var context = new CommandContext(command, fileSystem);

        chain.Handle(context);

        fileSystem.Received(1).CopyFile("Test1", "Test2");
    }

    [Fact]
    public void ListTest()
    {
        LocalFileSystem fileSystem = Substitute.For<LocalFileSystem>();

        IHandler chain = new ConnectHandler()
            .AddNext(new DisconnectHandler())
            .AddNext(new TreeHandler())
            .AddNext(new FileHandler());

        var command = new Command("tree list -d 3");
        var context = new CommandContext(command, fileSystem);

        chain.Handle(context);

        fileSystem.Received(1).ListFiles(3, 0, null);
    }
}