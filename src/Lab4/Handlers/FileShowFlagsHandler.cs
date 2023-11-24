using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileShowFlagsHandler
{
    private string _mode = "console";

    public void Execute(CommandContext context)
    {
        if (context is null) return;
        string path = (string)context.Iterator.Current;
        context.Iterator.MoveNext();

        Command iterator = context.Iterator.Clone();
        CheckForMode(iterator);

        context.FileSystem.OpenFile(path);
    }

    private void CheckForMode(Command iterator)
    {
        while (iterator.MoveNext())
        {
            if ((string)iterator.Current == "-m")
            {
                iterator.MoveNext();
                _mode = (string)iterator.Current;
            }
        }
    }
}