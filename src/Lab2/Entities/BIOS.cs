using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios : BasePart
{
    public Bios(string name, int type, int version)
        : base(name)
    {
        Type = type;
        Version = version;
    }

    public int Type { get; set; }
    public int Version { get; set; }
    public override Parts GetPart()
    {
        return Parts.BIOS;
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        throw new System.NotImplementedException();
    }
}