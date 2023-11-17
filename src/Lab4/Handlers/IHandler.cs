using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public interface IHandler
{
    public static abstract void Handle(Command iterator);
}