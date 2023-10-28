using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ComputerNotReadyException : Exception
{
    public ComputerNotReadyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ComputerNotReadyException(string message)
        : base(message)
    {
    }

    public ComputerNotReadyException()
    {
    }
}