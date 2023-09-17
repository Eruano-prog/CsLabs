using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class GammaWarpEngine : AbsWarpEngine
{
    private readonly int _maxDist;

    public GammaWarpEngine()
    {
        _maxDist = 15000;
    }

    public override int? Consumption(int dist)
    {
        if (dist > _maxDist)
        {
            return null;
        }

        return (int)Math.Pow(dist, 2);
    }
}