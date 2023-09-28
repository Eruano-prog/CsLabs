namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public abstract class BaseWarpEngine
{
    private readonly int _maxDist;

    protected BaseWarpEngine() { }
    protected BaseWarpEngine(int max) => _maxDist = max;

    public virtual int? TimeToWarp(int dist)
    {
        if (dist > _maxDist) return null;
        return dist;
    }
}