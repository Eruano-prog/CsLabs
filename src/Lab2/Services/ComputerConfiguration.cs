using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerConfiguration
{
    public CPU? Cpu { get; internal set; }
    public DRAM? Dram { get; internal set; }
    public GraphicCard? GraphicCard { get; internal set; }
    public HDD? Hdd { get; internal set; }
    public Motherboard? BMotherboard { get; internal set; }
    public PCCase? Case { get; internal set; }
    public PSU? Psu { get; internal set; }
    public SSD? Ssd { get; internal set; }
}