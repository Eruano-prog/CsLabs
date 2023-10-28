using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class BasePart
{
    protected BasePart(string name)
    {
        Name = name;
    }

    public string Name { get; protected set; }

    public abstract Parts GetPart();

    public abstract bool CanBePlaced(ComputerConfiguration computer);
}