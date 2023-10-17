using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PcCase : BasePart
{
    public PcCase(string name, int motherboardSize, int gpuLenght, int gpuWidth)
        : base(name)
    {
        MotherboardSize = motherboardSize;
        GPULenght = gpuLenght;
        GPUWidth = gpuWidth;
    }

    public int MotherboardSize { get; set; }
    public int GPULenght { get; set; }
    public int GPUWidth { get; set; }
    public override Parts GetPart()
    {
        return Parts.PCCase;
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        throw new System.NotImplementedException();
    }
}