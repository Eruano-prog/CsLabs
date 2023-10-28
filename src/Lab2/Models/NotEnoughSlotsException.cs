namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class NotEnoughSlotsException : BuildException
{
    public NotEnoughSlotsException()
    {
    }

    public NotEnoughSlotsException(string message)
        : base(message)
    {
    }

    public NotEnoughSlotsException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}