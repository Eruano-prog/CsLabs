namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class InvalidComponentException : BuildException
{
    public InvalidComponentException()
    { }

    public InvalidComponentException(string message)
        : base(message)
    { }

    public InvalidComponentException(string message, System.Exception innerException)
        : base(message, innerException)
    { }
}