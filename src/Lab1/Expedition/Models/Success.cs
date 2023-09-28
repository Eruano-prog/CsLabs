namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record Success() : BaseTrackResult
{
    public Success(int time, int fuel)
        : this()
    {
        TimeToPass = time;
        FuelToPass = fuel;
    }
}