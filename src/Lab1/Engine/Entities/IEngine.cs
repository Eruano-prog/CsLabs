namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Entities;

public interface IEngine
{
    public int Consumption { get; }

    public int TimeToReach(int dist);
}