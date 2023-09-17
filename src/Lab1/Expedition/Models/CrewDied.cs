namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record CrewDied() : PassTrackResult
{
    public required string Message { get; init; }
}