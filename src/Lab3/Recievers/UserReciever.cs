using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recievers;

public class UserReciever : BaseReciever
{
    private List<RecievedMessage> _recieved;

    public UserReciever()
    {
        _recieved = new List<RecievedMessage>();
    }

    public override void Recieve(Message message)
    {
        _recieved.Add(new RecievedMessage(message, false));
    }

    public void ReadMessage(Message message)
    {
        for (int i = 0; i < _recieved.Count; i++)
        {
            if (_recieved[i].Message == message)
            {
                if (_recieved[i].Read)
                {
                    throw new AlreadyReadException("Message already marked as readed");
                }
                else
                {
                    _recieved[i] = new RecievedMessage(_recieved[i].Message, true);
                }
            }
        }
    }

    public bool IsRead(Message message)
    {
        foreach (RecievedMessage currentMessage in _recieved)
        {
            if (currentMessage.Message == message)
            {
                return currentMessage.Read;
            }
        }

        return false;
    }
}