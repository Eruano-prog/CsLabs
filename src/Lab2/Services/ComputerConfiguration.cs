using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerConfiguration
{
    public Cpu? Cpu { get; internal set; }
    public Dram? Dram { get; internal set; }
    public CPUCooler? Cooler { get; internal set; }
    public GraphicCard? GraphicCard { get; internal set; }
    public Hdd? Hdd { get; internal set; }
    public Motherboard? Motherboard { get; internal set; }
    public WiFiAdapter? WiFiAdapter { get; internal set; }
    public Psu? Psu { get; internal set; }
    public Ssd? Ssd { get; internal set; }
    public PcCase? PcCase { get; internal set; }
    public int CurPower { get; set; }
    public int CurPci { get; set; }
    public int CurSata { get; set; }

    public bool IsValid()
    {
        if (Cpu is null) return false;
        if (Dram is null) return false;
        if (Cooler is null) return false;
        if (GraphicCard is null) return false;
        if (Motherboard is null) return false;
        if (PcCase is null) return false;
        if (Hdd is null && Ssd is null) return false;
        return true;
    }
}