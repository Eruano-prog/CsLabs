using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using Itmo.ObjectOrientedProgramming.Lab3.Recievers;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic : IReciever
{
    private readonly IAddressee _addressee;
    public Topic(string title, IAddressee addressee)
    {
        _addressee = addressee;
        Title = title;
    }

    public string Title { get; private init; }

    public void Recieve(Message message)
    {
        _addressee.Process(message);
    }
}