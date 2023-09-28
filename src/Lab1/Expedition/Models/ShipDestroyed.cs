namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record ShipDestroyed() : BaseTrackResult
{
    public required string Message { get; init; }
}