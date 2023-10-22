using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Dram : BasePart
{
    public Dram(string name, string xmp, int memory, int frequency, int version, int form, int power)
        : base(name)
    {
        Xmp = xmp;
        Memory = memory;
        Frequency = frequency;
        Version = version;
        Form = form;
        Power = power;
    }

    public int Memory { get; set; }
    public int Frequency { get; set; }
    public int Version { get; set; }
    public int Form { get; set; }
    public int Power { get; set; }
    public string Xmp { get; set; }

    public override Parts GetPart()
    {
        return Parts.DRAM;
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        if (computer is null) return false;

        if (computer.Motherboard is not null && computer.Motherboard.DdrFrequency <= Frequency) throw new FailedToPlaceExeption("Frequency doesn`t match with motherboard`s");

        if (computer.Motherboard is not null && computer.Motherboard.DdrVersion != Version)
            throw new FailedToPlaceExeption("Ddr version doen`t match mothrboard`s");

        return true;
    }
}