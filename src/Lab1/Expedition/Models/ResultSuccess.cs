namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;

public sealed record ResultSuccess(int Time, int Fuel) : BaseTrackResult(Time, Fuel) { }