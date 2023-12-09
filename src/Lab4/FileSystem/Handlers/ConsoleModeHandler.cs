namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Handlers;

public class ConsoleModeHandler : BaseShowHandler
{
    public override void Handle(string filename, string mode = "console")
    {
        if (mode == "console")
        {
            this.AddNext(new ConsoleWriteHandler());
        }

        base.Handle(filename, mode);
    }
}