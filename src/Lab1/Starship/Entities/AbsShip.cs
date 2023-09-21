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
         AntiNitro = false;
     }

    public bool AntiNitro { get; protected set; }
    protected AbsHull Hull { get; init; }

    protected AbsDeflector? Deflector { get; init; }

    protected AbsEngine ImpulseEngine { get; init; }
    protected AbsWarpEngine? WarpEngine { get; init; }

    public virtual PassTrackResult Fly(int dist)
    {
        int result = ImpulseEngine.TimeToPass(dist);
        return new Success(result, result * ImpulseEngine.Consumption);
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
        if (Deflector is { IsWorking: true })
        {
            Deflector.TakeDamage(dmg);
            if (!Deflector.IsWorking)
            {
                dmg = int.Abs(Deflector.Durability);
            }
        }

        if (Deflector is { IsWorking: false })
        {
            Hull.TakeDamage(dmg);
        }

        return Hull.IsWorking;
    }

    public bool RejectFlare()
    {
        if (Deflector == null) return false;

        return Deflector.Flare();
    }

    public bool IsOk()
    {
        return Hull.IsWorking;
    }
}