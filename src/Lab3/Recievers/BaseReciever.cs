using System;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recievers;

public abstract class BaseReciever : IReciever
{
    public virtual void Recieve(Message message)
    {
        if (message is null) return;
        Console.WriteLine(message.Print());
    }
}