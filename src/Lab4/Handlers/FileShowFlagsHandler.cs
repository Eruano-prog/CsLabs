using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileShowFlagsHandler
{
    private Dictionary<string, string> flags = new Dictionary<string, string>()
    {
        { "-m", "console" },
    };

    public void Execute(CommandContext context)
    {
        if (context is null) return;
        string path = (string)context.Iterator.Current;

        var chain = new FileShowModeHandler();

        while (context.Iterator.MoveNext())
        {
            chain.Handle(context, flags);
        }

        context.FileSystem.OpenFile(path, flags["-m"]);
    }
}