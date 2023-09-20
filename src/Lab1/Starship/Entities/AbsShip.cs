using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public abstract class AbsShip
{
    private readonly AbsHull _hull;
    private readonly AbsEngine _impulseEngine;
    private readonly AbsWarpEngine? _warpEngine;

    protected AbsShip()
    {
        _hull = new FirstHull();
        _impulseEngine = new EngineC();
        _warpEngine = null;
    }

    public virtual PassTrackResult Fly(int dist)
    {
        int result = _impulseEngine.TimeToPass(dist);
        return new Success(result, result * _impulseEngine.Consumprion);
    }

    public virtual PassTrackResult Warp(int dist)
    {
        if (_warpEngine == null) return new ShipLost { Message = "No Warp Engine on the ship" };
        int? res = _warpEngine.TimeToWarp(dist);
        if (res == null) return new ShipLost { Message = "To long way to pass" };
        return new Success((int)res, (int)res * 100);
    }

    public bool Hit(int dmg)
    {
        _hull.TakeDamage(dmg);
        return _hull.IsWorking;
    }
}