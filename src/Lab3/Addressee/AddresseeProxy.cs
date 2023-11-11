using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;
using Itmo.ObjectOrientedProgramming.Lab3.MessageLogs;
using Itmo.ObjectOrientedProgramming.Lab3.Recievers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeProxy : IAddressee
{
    private IReciever _reciever;
    private Priorities _priority;
    private ILogger _logger;

    public AddresseeProxy(IReciever reciever, ILogger logger, Priorities priority = Priorities.TopSecret)
    {
        _reciever = reciever;
        _logger = logger;
        _priority = priority;
    }

    public void Process(Message message)
    {
        if (message is null) return;

        if (Filter(message))
        {
            _reciever.Recieve(message);
            _logger.WriteLog(message, true);
        }
        else
        {
            _logger.WriteLog(message, false);
        }
    }

    private bool Filter(Message message) => message.Priority <= _priority;
}