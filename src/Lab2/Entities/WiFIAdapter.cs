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
        if (computer is null) return false;
        if (computer.Motherboard is not null && computer.Motherboard.WiFi == true) throw new FailedToPlaceExeption("Motherboard already have wifi support");
        return true;
    }
}