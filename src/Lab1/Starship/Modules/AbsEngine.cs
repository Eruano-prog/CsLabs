namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public abstract class AbsEngine
{
    public int Consumption { get; protected init; }
    public bool CanPassNitro { get; init; }
    public abstract int TimeToPass(int dist);
}