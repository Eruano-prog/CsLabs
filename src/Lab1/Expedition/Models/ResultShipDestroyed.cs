namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record ResultShipDestroyed() : BaseTrackResult
{
    public required string Message { get; init; }
}