namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Handlers;

public abstract class BaseShowHandler
{
    private BaseShowHandler? _next;

    protected BaseShowHandler() { }

    protected BaseShowHandler(BaseShowHandler next)
    {
        _next = next;
    }

    public virtual void Handle(string filename, string mode = "console")
    {
        if (_next is not null)
        {
            _next.Handle(filename, mode);
        }
        else
        {
            return;
        }
    }

    public BaseShowHandler AddNext(BaseShowHandler handler)
    {
        _next = handler;
        return this;
    }
}