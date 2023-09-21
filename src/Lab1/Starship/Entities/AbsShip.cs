using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public abstract class AbsShip
{
    protected AbsShip()
     {
         Hull = new FirstHull();
         ImpulseEngine = new EngineC();
         WarpEngine = null;
         Deflector = null;
     }

    protected AbsHull Hull { get; set; }
    protected AbsDeflector? Deflector { get; set; }
    protected AbsEngine ImpulseEngine { get; set; }
    protected AbsWarpEngine? WarpEngine { get; set; }

    public virtual PassTrackResult Fly(int dist)
    {
        int result = ImpulseEngine.TimeToPass(dist);
        return new Success(result, result * ImpulseEngine.Consumprion);
    }

    public virtual PassTrackResult Warp(int dist)
    {
        if (WarpEngine == null) return new ShipLost { Message = "No Warp Engine on the ship" };
        int? res = WarpEngine.TimeToWarp(dist);
        if (res == null) return new ShipLost { Message = "To long way to pass" };
        return new Success((int)res, (int)res * 100);
    }

    public bool Hit(int dmg)
    {
        if (Deflector != null && Deflector.IsWorking) Deflector.TakeDamage(dmg);
        else Hull.TakeDamage(dmg);

        return Hull.IsWorking;
    }
}