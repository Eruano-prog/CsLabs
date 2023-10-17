using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd : BaseDrive
{
    public Ssd(string name, int capacity, int speed, int power, DriveConnection connection)
        : base(name, capacity, speed, power, connection) { }
    public override Parts GetPart()
    {
        return Parts.SSD;
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        throw new System.NotImplementedException();
    }
}