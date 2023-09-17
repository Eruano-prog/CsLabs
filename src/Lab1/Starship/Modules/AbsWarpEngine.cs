namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public abstract class AbsWarpEngine
{
    private readonly int _maxDist;
    public virtual int? Consumption(int dist);
}