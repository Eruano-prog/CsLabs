namespace Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

public class Message : IPrintable, IFiltarable
{
    private Priorities priority;

    public Message(string text, Priorities priority = Priorities.Open)
    {
        this.priority = priority;
        Text = text;
    }

    public string Text { get; private set; }

    public string Print() => Text;

    public bool Filter(Priorities priority) => this.priority < priority;
}