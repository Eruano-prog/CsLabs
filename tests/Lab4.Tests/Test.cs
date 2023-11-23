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
    public void Test1()
    {
        var command = new Command("C:\\Program Files'");
        LocalFyleSystem fileSystem = Substitute.For<LocalFyleSystem>();

        var context = new CommandContext(command, fileSystem);

        IHandler chain = new ConnectHandler()
            .AddNext(new DisconnectHandler())
            .AddNext(new TreeHandler())
            .AddNext(new FileHandler());

        chain.Handle(context);

        fileSystem.Received(1).Connect("C:\\Program Files");

        command = new Command("tree goto Git");
        context = new CommandContext(command, fileSystem);

        chain.Handle(context);

        fileSystem.Received(1).ChangeDirectory("Git");
    }
}