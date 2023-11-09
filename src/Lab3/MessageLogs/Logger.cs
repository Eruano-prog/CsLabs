using System;
using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageLogs;

public class Logger : ILogger
{
    private static Logger? _instance;

    private Logger()
    { }

    public static ILogger TakeInstance()
    {
        if (_instance is null)
        {
            _instance = new Logger();
        }

        return _instance;
    }

    public void WriteLog(Message message, bool result)
    {
        Console.WriteLine($"Message {message?.Text} is {(result ? string.Empty : "not")} printed");
    }
}