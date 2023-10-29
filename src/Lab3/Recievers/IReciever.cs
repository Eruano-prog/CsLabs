using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recievers;

public interface IReciever
{
    public void Recieve(Message message);
}