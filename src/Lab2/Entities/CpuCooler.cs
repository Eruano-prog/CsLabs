using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuCooler : BasePart
{
    public CpuCooler(string name, string socket, int tdp)
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
        if (computer is null) return false;

        if (computer.Motherboard is not null && computer.Motherboard.Socket != Socket) return false;
        if (computer.Cpu is not null && computer.Cpu.Socket != Socket) return false;

        return true;
    }
}