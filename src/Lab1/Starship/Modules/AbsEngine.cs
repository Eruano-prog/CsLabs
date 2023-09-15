namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public abstract class AbsEngine
{
    public int Consumprion { get; }
    public abstract int FuelToPass(int dist);
}