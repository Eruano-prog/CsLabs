using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public class GammaWarpEngine : BaseWarpEngine
{
    private readonly int _maxDistance;

    public GammaWarpEngine()
    {
        _maxDistance = 15000;
    }

    public override int? TimeToWarp(int distance)
    {
        if (distance > _maxDistance)
        {
            return null;
        }

        return (int)Math.Pow(distance, 2);
    }
}