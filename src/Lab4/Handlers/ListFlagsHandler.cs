using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class ListFlagsHandler
{
    private Dictionary<string, string> _flags = new Dictionary<string, string>()
    {
        { "-d", "1" },
    };

    public void Execute(CommandContext context)
    {
        if (context is null) return;

        context.Iterator.GetFlags(_flags);

        context.FileSystem.ListFiles(int.Parse(_flags["-d"], NumberFormatInfo.CurrentInfo), 0, null);
    }
}