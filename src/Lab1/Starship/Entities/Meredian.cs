using Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Entities;

public class Meredian : AbsShip
{
    private AbsEngine impulseEngine;
    private AbsWarpEngine? warpEngine;

    public Meredian()
    {
        impulseEngine = new EngineE();
    }
}