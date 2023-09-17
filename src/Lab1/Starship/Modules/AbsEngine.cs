namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public abstract class AbsEngine
{
    public int Consumprion { get; }
    public bool AntiNitro { get; }
    public abstract int TimeToPass(int dist);
}