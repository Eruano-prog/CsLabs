using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class NotEnoughPowerException : Exception
{
    public NotEnoughPowerException()
    {
    }

    public NotEnoughPowerException(string message)
        : base(message)
    {
    }

    public NotEnoughPowerException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}