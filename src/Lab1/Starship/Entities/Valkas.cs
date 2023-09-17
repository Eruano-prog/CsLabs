using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Valkas : AbsShip
{
    private AbsEngine impulseEngine;
    private AbsWarpEngine? warpEngine;

    public Valkas()
    {
        impulseEngine = new EngineE();
        warpEngine = new GammaWarpEngine();
    }
}