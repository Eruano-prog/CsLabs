using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class ConnectHandler : BaseHandler
{
    public ConnectHandler()
        : base(new DisconnectHandler())
    { }

    public ConnectHandler(IHandler next)
        : base(next)
    { }

    public override void Handle(CommandContext context)
    {
        if (context is null || context.Iterator is null) return;
        if (string.Equals((string)context.Iterator.Current, "connect", StringComparison.Ordinal))
        {
            context.Iterator.MoveNext();
            context.FileSystem.Connect((string)context.Iterator.Current);
        }
        else
        {
            base.Handle(context);
        }
    }
}