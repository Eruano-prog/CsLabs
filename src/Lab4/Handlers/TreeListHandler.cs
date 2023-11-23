using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class TreeListHandler : BaseHandler
{
    public override void Handle(CommandContext context)
    {
        if (context is null || context.Iterator is null) return;
        if (string.Equals((string)context.Iterator.Current, "list", StringComparison.Ordinal))
        {
            context.FileSystem.ListFiles(2, 0);
        }
        else
        {
            base.Handle(context);
        }
    }
}