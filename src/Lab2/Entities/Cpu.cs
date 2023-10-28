using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : BasePart
{
    public Cpu(string name, string socket, bool graphic, int tdp, int minBios, int power)
        : base(name)
    {
        Socket = socket;
        Graphic = graphic;
        Tdp = tdp;
        MinBios = minBios;
        Power = power;
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

        if (computer.Motherboard is not null && computer.Motherboard.Socket != Socket) throw new FailedToPlaceExeption("Socket does`t match with motherboard");

        if (computer.Motherboard is not null && computer.Motherboard.Bios.Version < MinBios) throw new FailedToPlaceExeption("Bios version does`t match with motherboard");

        return true;
    }
}