using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileShowHandler : BaseHandler
{
    public override void Handle(CommandContext context)
    {
        if (context is null || context.Iterator is null) return;
        if (string.Equals((string)context.Iterator.Current, "show", StringComparison.Ordinal))
        {
            context.Iterator.MoveNext();
            string path = (string)context.Iterator.Current;
            context.FileSystem.OpenFile(path);
        }
        else
        {
            base.Handle(context);
        }
    }
}