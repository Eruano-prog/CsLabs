namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record CrewDied() : BaseTrackResult
{
    public required string Message { get; init; }
}