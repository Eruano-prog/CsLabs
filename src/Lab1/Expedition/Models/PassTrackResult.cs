namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public abstract record PassTrackResult
{
    protected PassTrackResult() { }
    public int TimeToPass { get; init; }
    public int FuelToPass { get; init; }
}