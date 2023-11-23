using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class TreeHandler : BaseHandler
{
    public override void Handle(CommandContext context)
    {
        if (context is null || context.Iterator is null) return;
        if (string.Equals((string)context.Iterator.Current, "goto", StringComparison.Ordinal))
        {
            context.Iterator.MoveNext();

            IHandler treeChain = new TreeGotoHandler().AddNext(new TreeListHandler());
            treeChain.Handle(context);
        }
        else
        {
            base.Handle(context);
        }
    }
}