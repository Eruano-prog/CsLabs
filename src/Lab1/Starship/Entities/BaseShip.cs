using Itmo.ObjectOrientedProgramming.Lab1.Expedition.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public abstract class BaseShip
{
    protected BaseShip()
     {
         Hull = new FirstHull();
         ImpulseEngine = new EngineC();
         WarpEngine = null;
         Deflector = null;
         AntiNitro = false;
     }

    public bool AntiNitro { get; protected set; }
    protected BaseHull Hull { get; init; }

    protected BaseDeflector? Deflector { get; init; }

    protected BaseEngine ImpulseEngine { get; init; }
    protected BaseWarpEngine? WarpEngine { get; init; }

    public virtual BaseTrackResult Fly(int distance)
    {
        int result = ImpulseEngine.TimeToPass(distance);
        return new ResultSuccess(result, result * ImpulseEngine.Consumption);
    }

    public virtual BaseTrackResult Warp(int distance)
    {
        if (WarpEngine == null) return new ResultShipLost { Message = "No Warp Engine on the ship" };
        int? res = WarpEngine.TimeToWarp(distance);
        int? result = WarpEngine.TimeToWarp(distance);
        if (result is null) return new ResultShipLost { Message = "To long way to pass" };
        return new ResultSuccess((int)result, (int)result * 100);
    }

    public bool Hit(int damage)
    {
        if (Deflector is { IsWorking: true })
        {
            Deflector.TakeDamage(damage);
            if (!Deflector.IsWorking)
            {
                damage = int.Abs(Deflector.Durability);
            }
        }

        if (Deflector is { IsWorking: false })
        {
            Hull.TakeDamage(damage);
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

    public bool FlyThroughNitro()
    {
        return ImpulseEngine.CanPassNitro;
    }
}