using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerConfiguration
{
    public Cpu? Cpu { get; internal set; }
    public Dram? Dram { get; internal set; }
    public CpuCooler? Cooler { get; internal set; }
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

    public Parts? IsValid()
    {
        if (Cpu is null) return Parts.CPU;
        if (Dram is null) return Parts.DRAM;
        if (Cooler is null) return Parts.CPUCooler;
        if (GraphicCard is null) return Parts.GraphicCard;
        if (Motherboard is null) return Parts.Motherboard;
        if (PcCase is null) return Parts.PCCase;
        if (Hdd is null && Ssd is null) return Parts.HDD;
        return null;
    }
}