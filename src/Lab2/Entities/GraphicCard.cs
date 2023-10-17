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
        throw new System.NotImplementedException();
    }
}