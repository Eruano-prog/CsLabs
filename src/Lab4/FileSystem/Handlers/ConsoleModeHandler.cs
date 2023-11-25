using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Handlers;

public class ConsoleModeHandler : BaseShowHandler
{
    public override void Handle(string filename, string mode = "console")
    {
        if (mode == "console")
        {
            string fileContains = File.ReadAllText(filename);
            Console.WriteLine(fileContains);
        }
        else
        {
            base.Handle(filename, mode);
        }
    }
}