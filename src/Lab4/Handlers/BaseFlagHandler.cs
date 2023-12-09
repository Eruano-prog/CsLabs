using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class BaseFlagHandler
{
    private BaseFlagHandler? _next;

    protected BaseFlagHandler() { }

    protected BaseFlagHandler(BaseFlagHandler next)
    {
        _next = next;
    }

    public virtual bool Handle(CommandContext context, Dictionary<string, string> flags)
    {
        if (_next is not null)
        {
            return _next.Handle(context, flags);
        }
        else
        {
            return false;
        }
    }

    public virtual BaseFlagHandler AddNext(BaseFlagHandler handler)
    {
        _next = handler;

        return handler;
    }
}