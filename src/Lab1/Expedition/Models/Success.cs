namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record Success() : PassTrackResult
{
    public int TimeToPass { get; init; }
    public int FuelToPass { get; init; }
}