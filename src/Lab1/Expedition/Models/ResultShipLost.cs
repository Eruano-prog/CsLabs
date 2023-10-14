namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record ResultShipLost(string Message) : BaseTrackResult(0, 0) { }