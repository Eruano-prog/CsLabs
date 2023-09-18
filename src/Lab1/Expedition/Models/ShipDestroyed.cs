namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record ShipDestroyed() : PassTrackResult
{
    public required string Message { get; init; }
}