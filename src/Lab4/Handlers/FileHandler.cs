using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileHandler : BaseHandler
{
    public override void Handle(CommandContext context)
    {
        if (context is null || context.Iterator is null) return;
        if (string.Equals((string)context.Iterator.Current, "file", StringComparison.Ordinal))
        {
            context.Iterator.MoveNext();

            IHandler fileChain = new FileShowHandler();
            fileChain.AddNext(new FileMoveHandler())
                .AddNext(new FileCopyHandler())
                .AddNext(new FileDeleteHandler())
                .AddNext(new FileDeleteHandler());

            fileChain.Handle(context);
        }
        else
        {
            base.Handle(context);
        }
    }
}