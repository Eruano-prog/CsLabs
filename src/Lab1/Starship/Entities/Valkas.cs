using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Valkas : AbsShip
{
    private AbsEngine _impulseEngine;
    private AbsWarpEngine? _warpEngine;

    public Valkas()
    {
        _impulseEngine = new EngineE();
        _warpEngine = new GammaWarpEngine();
    }
}