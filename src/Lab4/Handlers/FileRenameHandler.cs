using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileRenameHandler : BaseHandler
{
    public override void Handle(CommandContext context)
    {
        if (context is null || context.Iterator is null) return;
        if (string.Equals((string)context.Iterator.Current, "rename", StringComparison.Ordinal))
        {
            context.Iterator.MoveNext();
            string path = (string)context.Iterator.Current;
            context.Iterator.MoveNext();
            string name = (string)context.Iterator.Current;

            context.FileSystem.RenameFile(path, name);
        }
        else
        {
            base.Handle(context);
        }
    }
}