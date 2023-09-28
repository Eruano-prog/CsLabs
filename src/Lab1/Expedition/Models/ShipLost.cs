namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record ShipLost() : BaseTrackResult
{
    public required string Message { get; init; }
}