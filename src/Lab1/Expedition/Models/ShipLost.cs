namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record ShipLost() : PassTrackResult
{
    public required string Message { get; init; }
}