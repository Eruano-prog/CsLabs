namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public abstract record PassTrackResult
{
    private PassTrackResult() { }

    public sealed record Success : PassTrackResult;
    public sealed record ShipLost : PassTrackResult;
    public sealed record ShipDestroyed : PassTrackResult;
    public sealed record CrewDied : PassTrackResult;
}