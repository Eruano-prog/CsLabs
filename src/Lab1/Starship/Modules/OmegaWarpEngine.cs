using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class OmegaWarpEngine : AbsWarpEngine
{
    private readonly int _maxDist;

    public OmegaWarpEngine()
    {
        _maxDist = 10000;
    }

    public override int? Consumption(int dist)
    {
        if (dist > _maxDist)
        {
            return null;
        }

        return dist * (int)Math.Log(dist);
    }
}