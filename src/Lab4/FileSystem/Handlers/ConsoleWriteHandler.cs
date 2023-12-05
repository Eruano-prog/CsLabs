using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Handlers;

public class ConsoleWriteHandler : BaseShowHandler
{
    public override void Handle(string filename, string mode = "console")
    {
        string fileContains = File.ReadAllText(filename);
        Console.WriteLine(fileContains);
        base.Handle(filename, mode);
    }
}