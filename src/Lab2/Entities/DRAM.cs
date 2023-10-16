using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class DRAM : IPart
{
    public DRAM(string xmp)
    {
        Xmp = xmp;
    }

    public string Xmp { get; set; }

    public bool CanBePlaced(ComputerConfiguration computer)
    {
        throw new System.NotImplementedException();
    }
}