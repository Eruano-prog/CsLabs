namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record ResultSuccess() : BaseTrackResult
{
    public ResultSuccess(int time, int fuel)
        : this()
    {
        TimeToPass = time;
        FuelToPass = fuel;
    }
}