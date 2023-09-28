namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record ResultCrewDied() : BaseTrackResult
{
    public required string Message { get; init; }
}