using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using Itmo.ObjectOrientedProgramming.Lab3.Recievers;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic : IReciever
{
    private readonly BaseReciever _reciever;
    public Topic(string title, BaseReciever reciever)
    {
        _reciever = reciever;
        Title = title;
    }

    public string Title { get; private init; }

    public void Recieve(Message message)
    {
        throw new System.NotImplementedException();
    }
}