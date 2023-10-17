using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CPUCooler : BasePart
{
    public CPUCooler(string name, string socket, int tdp)
        : base(name)
    {
        Socket = socket;
        Tdp = tdp;
    }

    public string Socket { get; set; }
    public int Tdp { get; set; }
    public override Parts GetPart()
    {
        throw new System.NotImplementedException();
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        throw new System.NotImplementedException();
    }
}