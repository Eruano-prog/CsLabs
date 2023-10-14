using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class OmegaWarpEngine : BaseWarpEngine
{
    private readonly int _maxDistance;

    public OmegaWarpEngine()
    {
        _maxDistance = 10000;
    }

    public override int? TimeToWarp(int distance)
    {
        if (distance > _maxDistance)
        {
            return null;
        }

        return distance * (int)Math.Log(distance);
    }
}