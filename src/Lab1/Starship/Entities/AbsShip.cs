using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public abstract class AbsShip
{
    private AbsEngine impulseEngine;
    private AbsWarpEngine? warpEngine;

    public virtual PassTrackResult Fly(int dist)
    {
        int result = impulseEngine.TimeToPass(dist);
        return new Success(result, result * impulseEngine.Consumprion);
    }
}