using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recievers;

public class GroupReciever : BaseReciever
{
    private Collection<IReciever> recievers;

    public GroupReciever(Collection<IReciever> recievers)
    {
        this.recievers = recievers;
    }

    public override void Recieve(Message message)
    {
        foreach (IReciever reciever in recievers)
        {
            reciever.Recieve(message);
        }
    }
}