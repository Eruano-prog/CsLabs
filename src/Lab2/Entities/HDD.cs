using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : BaseDrive
{
    public Hdd(string name, int capacity, int speed, int power)
        : base(name, capacity, speed, power, DriveConnection.Sata) { }
    public override Parts GetPart()
    {
        return Parts.HDD;
    }

    public override bool CanBePlaced(ComputerConfiguration computer)
    {
        throw new System.NotImplementedException();
    }
}