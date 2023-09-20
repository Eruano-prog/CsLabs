namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public abstract class AbsWarpEngine
{
    private readonly int _maxDist;

    protected AbsWarpEngine() { }
    protected AbsWarpEngine(int max) => _maxDist = max;

    public virtual int? TimeToWarp(int dist)
    {
        if (dist > _maxDist) return null;
        return dist;
    }
}