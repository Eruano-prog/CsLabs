using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class GraphicCard : BasePart
{
    public GraphicCard(string name, int memory, int pcie, int frequency, int power, int lenght, int width)
        : base(name)
    {
        Memory = memory;
        PCIE = pcie;
        Frequency = frequency;
        Power = power;
        Lenght = lenght;
        Width = width;
    }

    public int Memory { get; set; }
    public int PCIE { get; set; }
    public int Frequency { get; set; }
    public int Power { get; set; }
    public int Lenght { get; set; }
    public int Width { get; set; }
    public override Parts GetPart()
    {
        return Parts.GraphicCard;
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        if (computer is null) return false;

        if (computer.PcCase is not null && (computer.PcCase.GPUWidth < Width || computer.PcCase.GPULenght < Lenght)) return false;

        return true;
    }
}