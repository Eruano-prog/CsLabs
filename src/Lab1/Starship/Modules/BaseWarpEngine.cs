namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public abstract class BaseWarpEngine
{
    private readonly int _maxDistance;

    protected BaseWarpEngine() { }
    protected BaseWarpEngine(int max) => _maxDistance = max;

    public virtual int? TimeToWarp(int distance)
    {
        if (distance > _maxDistance) return null;
        return distance;
    }
}