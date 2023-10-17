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
}