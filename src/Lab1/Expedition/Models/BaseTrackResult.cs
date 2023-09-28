namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public abstract record BaseTrackResult
{
    protected BaseTrackResult() { }
    public int TimeToPass { get; init; }
    public int FuelToPass { get; init; }
}