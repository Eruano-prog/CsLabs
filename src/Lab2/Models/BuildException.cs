using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public abstract class BuildException : Exception
{
    protected BuildException() { }

    protected BuildException(string message)
        : base(message) { }

    protected BuildException(string message, Exception innerException)
        : base(message, innerException) { }
}