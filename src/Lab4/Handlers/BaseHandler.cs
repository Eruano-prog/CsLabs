using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public abstract class BaseHandler : IHandler
{
    private IHandler? _next;

    protected BaseHandler() { }

    protected BaseHandler(IHandler next)
    {
        _next = next;
    }

    public virtual void Handle(CommandContext context)
    {
        if (_next is not null)
        {
            _next.Handle(context);
        }
        else
        {
            return;
        }
    }

    public virtual IHandler AddNext(IHandler handler)
    {
        _next = handler;

        return handler;
    }
}