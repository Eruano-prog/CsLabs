using System;
using Itmo.ObjectOrientedProgramming.Lab3.MessageLogs;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recievers;

public class DisplayDriver
{
    private ILogger _logger;

    public DisplayDriver(ILogger logger)
    {
        _logger = logger;
    }

    public void SetText(string text)
    {
        Console.WriteLine(text);
        _logger.WriteLog($"{text} is written by Display");
    }

    public void Clear()
    {
        Console.Clear();
        _logger.WriteLog("Console is cleared");
    }

    public void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        _logger.WriteLog($"Display color changed to {color}");
    }
}