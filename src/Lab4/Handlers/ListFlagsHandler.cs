using Itmo.ObjectOrientedProgramming.Lab4.Iterator;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class ListFlagsHandler
{
    private int _depth = 1;

    public void Execute(CommandContext context)
    {
        if (context is null) return;

        Command iterator = context.Iterator.Clone();
        CheckForDepth(iterator);

        context.FileSystem.ListFiles(_depth, 0, null);
    }

    private void CheckForDepth(Command iterator)
    {
        while (iterator.MoveNext())
        {
            if ((string)iterator.Current == "-d")
            {
                iterator.MoveNext();
                string res = (string)iterator.Current;

                bool success = int.TryParse(res, out _depth);
                if (!success)
                {
                    _depth = 1;
                }
            }
        }
    }
}