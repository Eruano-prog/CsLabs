using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileMoveHandler : BaseHandler
{
    public override void Handle(CommandContext context)
    {
        if (context is null || context.Iterator is null) return;
        if (string.Equals((string)context.Iterator.Current, "move", StringComparison.Ordinal))
        {
            context.Iterator.MoveNext();
            string firstPath = (string)context.Iterator.Current;
            context.Iterator.MoveNext();
            string secondPath = (string)context.Iterator.Current;
            context.FileSystem.MoveFile(firstPath, secondPath);
        }
        else
        {
            base.Handle(context);
        }
    }
}