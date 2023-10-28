namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class FailedToPlaceExeption : BuildException
{
    public FailedToPlaceExeption()
    {
    }

    public FailedToPlaceExeption(string message)
        : base(message)
    {
    }

    public FailedToPlaceExeption(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}