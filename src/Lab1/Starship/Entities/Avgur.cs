using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Avgur : AbsShip
{
    private AbsEngine _impulseEngine;
    private AbsWarpEngine? _warpEngine;

    public Avgur()
    {
        _impulseEngine = new EngineE();
        _warpEngine = new AlphaWarpEngine();
    }
}