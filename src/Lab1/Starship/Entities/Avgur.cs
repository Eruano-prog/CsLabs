using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Avgur : AbsShip
{
    private AbsEngine impulseEngine;
    private AbsWarpEngine? warpEngine;

    public Avgur()
    {
        impulseEngine = new EngineE();
        warpEngine = new AlphaWarpEngine();
    }
}