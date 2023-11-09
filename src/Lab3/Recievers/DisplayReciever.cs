using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recievers;

public class DisplayReciever : BaseReciever
{
    private DisplayDriver _displayDriver;
    public DisplayReciever(DisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public override void Recieve(Message message)
    {
        if (message is null) return;

        _displayDriver.SetText(message.Text);
    }
}