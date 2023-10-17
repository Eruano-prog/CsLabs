using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerConfiguration
{
    public Cpu? Cpu { get; internal set; }
    public Dram? Dram { get; internal set; }
    public GraphicCard? GraphicCard { get; internal set; }
    public Hdd? Hdd { get; internal set; }
    public Motherboard? BMotherboard { get; internal set; }
    public PcCase? Case { get; internal set; }
    public Psu? Psu { get; internal set; }
    public Ssd? Ssd { get; internal set; }
}