using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Psu : BasePart
{
    public Psu(string name, int power)
        : base(name)
    {
        Power = power;
    }

    public int Power { get; set; }
    public override Parts GetPart()
    {
        throw new System.NotImplementedException();
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        if (computer is null) return false;
        return true;
    }
}