using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class BaseDrive : BasePart
{
    protected BaseDrive(string name, int capacity, int speed, int power, DriveConnection connection)
        : base(name)
    {
        Capacity = capacity;
        Speed = speed;
        Power = power;
        Connection = connection;
    }

    public DriveConnection Connection { get; set; }
    public int Capacity { get; set; }
    public int Speed { get; set; }
    public int Power { get; set; }
}