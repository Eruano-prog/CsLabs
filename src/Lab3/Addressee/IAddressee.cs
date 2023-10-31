using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public interface IAddressee
{
    public void Process(Message message);
}