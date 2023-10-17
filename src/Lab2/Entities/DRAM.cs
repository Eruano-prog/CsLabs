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
        throw new System.NotImplementedException();
    }
}