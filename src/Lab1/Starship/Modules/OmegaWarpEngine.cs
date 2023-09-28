using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class OmegaWarpEngine : BaseWarpEngine
{
    private readonly int _maxDist;

    public OmegaWarpEngine()
    {
        _maxDist = 10000;
    }

    public override int? TimeToWarp(int dist)
    {
        if (dist > _maxDist)
        {
            return null;
        }

        return dist * (int)Math.Log(dist);
    }
}