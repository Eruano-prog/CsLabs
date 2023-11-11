using System;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recievers;

public class MessangerReciever : BaseReciever
{
    public override void Recieve(Message message)
    {
        if (message is null) return;
        Console.WriteLine($"{message.Print()} is send to messanger");
    }
}