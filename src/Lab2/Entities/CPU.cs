using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : BasePart
{
    public Cpu(string name, string socket, bool graphic, int tdp, int minBios)
        : base(name)
    {
        Socket = socket;
        Graphic = graphic;
        Tdp = tdp;
        MinBios = minBios;
    }

    public string Socket { get; set; }
    public bool Graphic { get; set; }
    public int Tdp { get; set; }
    public int Power { get; set; }
    public int MinBios { get; set; }
    public override Parts GetPart()
    {
        return Parts.CPU;
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        if (computer is null) return false;

        if (computer.Motherboard?.Socket != Socket) return false;

        if (computer.Motherboard?.Bios.Version < MinBios) return false;

        return true;
    }
}