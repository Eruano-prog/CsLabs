using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Motherboard : BasePart
{
    public Motherboard(string name, string socket, int pciCount, int sataCount, int ddrVersion, int chipset, int ddrCount, Bios bios, bool wiFi, int ddrFrequency)
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
        DdrFrequency = ddrFrequency;
    }

    public string Socket { get; set; }
    public int PciCount { get; set; }
    public int SataCount { get; set; }
    public int DdrVersion { get; set; }
    public int Chipset { get; set; }
    public int DdrCount { get; set; }
    public int DdrFrequency { get; set; }
    public Bios Bios { get; set; }
    public bool WiFi { get; set; }

    public override Parts GetPart()
    {
        return Parts.Motherboard;
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        if (computer is null) return false;
        if (computer.Cpu is not null && Bios.Version < computer.Cpu.MinBios)
            throw new FailedToPlaceExeption("Bios version doen`t match");
        if (computer.Cpu is not null && Socket != computer.Cpu.Socket)
            throw new FailedToPlaceExeption("Socket doesn`t match");
        if (computer.Dram is not null && DdrVersion != computer.Dram.Version)
            throw new FailedToPlaceExeption("Dram version doesn`t match");
        if (computer.WiFiAdapter is not null && WiFi) throw new FailedToPlaceExeption("WiFi adapter already placed");

        return true;
    }
}