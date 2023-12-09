using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public interface IHandler
{
    public void Handle(CommandContext context);
    public IHandler AddNext(IHandler handler);
}