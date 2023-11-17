using System;
using Itmo.ObjectOrientedProgramming.Lab4.Iterator;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class ConnectHandler : IHandler
{
    public static void Handle(Command iterator)
    {
        if (iterator == null) return;
        if (string.Equals((string)iterator.Current, "connect", StringComparison.Ordinal))
        {
        }
    }
}