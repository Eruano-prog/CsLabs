using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapter : BasePart
{
    public WiFiAdapter(string name, int pci, int power)
        : base(name)
    {
        Pci = pci;
        Power = power;
    }

    public int Pci { get; set; }
    public int Power { get; set; }
    public override Parts GetPart()
    {
        return Parts.WiFiAdapter;
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        throw new System.NotImplementedException();
    }
}