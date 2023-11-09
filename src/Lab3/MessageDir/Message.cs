namespace Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

public class Message : IPrintable
{
    public Message(string text, Priorities priority = Priorities.Open)
    {
        this.Priority = priority;
        Text = text;
    }

    public Priorities Priority { get; private set; }

    public string Text { get; private set; }

    public string Print() => Text;
}