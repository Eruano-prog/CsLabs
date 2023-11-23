using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        IHandler chain = new ConnectHandler();
        chain.AddNext(new DisconnectHandler())
            .AddNext(new TreeHandler())
            .AddNext(new FileHandler());
        var fileSystem = new LocalFyleSystem();

        while (true)
        {
            string? command = Console.ReadLine();

            if (command is null) continue;

            var iterator = new Command(command);

            var context = new CommandContext(iterator, fileSystem);

            chain.Handle(context);
        }
    }
}