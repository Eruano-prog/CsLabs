namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class NotEnoughTdpException : BuildException
{
    public NotEnoughTdpException() { }

    public NotEnoughTdpException(string message)
        : base(message) { }

    public NotEnoughTdpException(string message, System.Exception innerException)
        : base(message, innerException) { }
}