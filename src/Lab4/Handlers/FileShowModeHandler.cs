using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileShowModeHandler : BaseFlagHandler
{
    public override bool Handle(CommandContext context, Dictionary<string, string> flags)
    {
        if (context is null || flags is null) return false;

        if ((string)context.Iterator.Current == "-m")
        {
            context.Iterator.MoveNext();
            flags["-m"] = (string)context.Iterator.Current;
            return true;
        }

        return base.Handle(context, flags);
    }
}