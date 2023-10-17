using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Motherboard : BasePart
{
    public Motherboard(string name, string socket, int pciCount, int sataCount, int ddrVersion, int chipset, int ddrCount, Bios bios, bool wiFi)
        : base(name)
    {
        Socket = socket;
        PciCount = pciCount;
        SataCount = sataCount;
        DdrVersion = ddrVersion;
        Chipset = chipset;
        DdrCount = ddrCount;
        Bios = bios;
        WiFi = wiFi;
    }

    public string Socket { get; set; }
    public int PciCount { get; set; }
    public int SataCount { get; set; }
    public int DdrVersion { get; set; }
    public int Chipset { get; set; }
    public int DdrCount { get; set; }
    public Bios Bios { get; set; }
    public bool WiFi { get; set; }

    public override Parts GetPart()
    {
        return Parts.Motherboard;
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        throw new System.NotImplementedException();
    }
}