using Itmo.ObjectOrientedProgramming.Lab3.MessageDir;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageLogs;

public interface ILogger
{
    public static abstract ILogger TakeInstance();
    public void WriteLog(Message message, bool result);
    public void WriteLog(string message);
}