namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record Success() : PassTrackResult
{
    public Success(int TimeToPass, int FuelToPass);
    public required int TimeToPass { get; init; }
    public required int FuelToPass { get; init; }
}