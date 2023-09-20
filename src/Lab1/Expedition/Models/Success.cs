namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record Success() : PassTrackResult
{
    public Success(int time, int fuel)
        : this()
    {
        TimeToPass = time;
        FuelToPass = fuel;
    }
}