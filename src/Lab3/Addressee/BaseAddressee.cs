using Itmo.ObjectOrientedProgramming.Lab3.Logs;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using Itmo.ObjectOrientedProgramming.Lab3.Recievers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class BaseAddressee : IAddressee
{
    private IReciever _reciever;
    private Priorities _priority;
    private ILogger _logger;

    public BaseAddressee(IReciever reciever, Priorities priority = Priorities.TopSecret)
    {
        _reciever = reciever;
        _logger = Logger.TakeInstance();
        _priority = priority;
    }

    public void Process(Message message)
    {
        if (message is null) return;

        if (message.Filter(_priority))
        {
            _reciever.Recieve(message);
            _logger.WriteLog(message, true);
        }
        else
        {
            _logger.WriteLog(message, false);
        }
    }
}