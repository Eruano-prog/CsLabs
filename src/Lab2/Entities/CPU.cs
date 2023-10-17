using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : BasePart
{
    public Cpu(string name, string socket, bool graphic, int tdp)
        : base(name)
    {
        Socket = socket;
        Graphic = graphic;
        Tdp = tdp;
    }

    public string Socket { get; set; }
    public bool Graphic { get; set; }
    public int Tdp { get; set; }
    public override Parts GetPart()
    {
        return Parts.CPU;
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        throw new System.NotImplementedException();
    }
}